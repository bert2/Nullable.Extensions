# Nullable.Extensions

[![build](https://img.shields.io/appveyor/build/bert2/nullable-extensions/master?logo=appveyor)](https://ci.appveyor.com/project/bert2/nullable-extensions/branch/master) [![tests](https://img.shields.io/appveyor/tests/bert2/nullable-extensions/master?compact_message&logo=appveyor)](https://ci.appveyor.com/project/bert2/nullable-extensions/branch/master) [![coverage](https://img.shields.io/codecov/c/github/bert2/Nullable.Extensions/master?logo=codecov)](https://codecov.io/gh/bert2/Nullable.Extensions) [![nuget package](https://img.shields.io/nuget/v/Nullable.Extensions.svg?logo=nuget)](https://www.nuget.org/packages/Nullable.Extensions) [![nuget downloads](https://img.shields.io/nuget/dt/Nullable.Extensions?color=blue&logo=nuget)](https://www.nuget.org/packages/Nullable.Extensions) ![last commit](https://img.shields.io/github/last-commit/bert2/Nullable.Extensions/master?logo=github)

`Nullable.Extensions` is a set of C# extension methods to help working with nullable types by implementing the [Maybe monad](https://www.dotnetcurry.com/patterns-practices/1510/maybe-monad-csharp) on top of `T?`. This includes nullable value types (`Nullable<T>`s or NVTs) and nullable reference types (NRTs).

If your interested in the reasoning behind this library, I recommend that you read the chapter ["Make null explicit"](https://gist.github.com/bert2/2413ea125992fe59d66d24238cf9eba7#make-null-explicit) from my guide [Giving Sisyphus a Hand: How to Improve OOP with Functional Principles](https://gist.github.com/bert2/2413ea125992fe59d66d24238cf9eba7).

## Prerequisites

- dotnet core 3.1, C# 8.0
- enabled nullable reference types (via `<Nullable>enable</Nullable>` in your `.csproj` file or `#nullable enable` in your `.cs` file)
- import the required namespaces:

```csharp
using Nullable.Extensions; // extension methods
using Nullable.Extensions.Async; // async variants of the extension methods (see notes below)

// optional:
using static Nullable.Extensions.NullableClass; // factory method for NRTs
using static Nullable.Extensions.NullableStruct; // factory method for NVTs
using static Nullable.Extensions.TryParseFunctions; // helper functions to try-parse built-in types as `T?`
```

## Usage examples

```csharp
int num = GetUserInput() // returns `string?`
    .Filter(s => s.All(char.IsDigit))
    .Filter(s => s.Length < 10)
    .Map(int.Parse)
    ?? throw new Exception("No input given or input was not numeric");
```

```csharp
using static Nullable.Extensions.TryParseFunctions;

int num = Nullable("abc")
    .Bind(TryParseInt)
    ?? throw new Exception("No input given or input was not numeric");
```

```csharp
int num = GetUserInput() // returns `string?`
    .Bind(TryParseInt)
    .Switch(notNull: n => n - 1, isNull: () => 0);
```

```csharp
int num = "123"
    .AsNullable()
    .Bind(TryParseInt)
    .Map(n => n - 1)
    ?? 0;
```

## Working with `Task<T?>`

The namespace `Nullable.Extensions.Async` contains asynchronous variants of most of the extension methods. Importing them enables the fluent API on `Task<T?>`.

```csharp
using Nullable.Extensions;
using Nullable.Extensions.Async;
using static Nullable.Extensions.TryParseFunctions;

public async Task<User?> LoadUser(int id) => // ...

string userName = await requestParams // a `Dictionary<string, string>`
    .TryGetValue("userId")            // from `Nullable.Extensions`
    .Bind(TryParseInt)                // from `Nullable.Extensions`
    .BindAsync(LoadUser)              // from `Nullable.Extensions.Async`
    .Map(u => u.Name)                 // from `Nullable.Extensions.Async`
    ?? "n/a";
```

Note that you only have to `await` the result once at the very top of the method chain.

### Fixing "The call is ambiguous between..."

When you are using extension methods from `Nullable.Extensions.Async`, you might occasionally encounter an error due to the compiler being unable to determine the correct overload:

```csharp
string? msg = await Task
    .FromResult<string?>("world")
    .Map(s => $"Hello, {s}!"); // ERROR CS0121
```

> CS0121: The call is ambiguous between the following methods or properties: 'Map<T1, T2>(T1?, Func<T1, T2>)' and 'Map<T1, T2>(Task<T1?>, Func<T1, T2>)'

Fortunately, this is easy to fix by assisting the type inference with an explicit type declaration on the lambda parameter:

```csharp
string? msg = await Task
    .FromResult<string?>("world")
    .Map((string s) => $"Hello, {s}!"); // no error
```

The fix is only needed under [certain circumstances](https://stackoverflow.com/questions/60754529/how-to-explain-this-call-is-ambiguous-error). Most of the time this fix should not be needed and you can let the compiler infer the type.

## Method reference

### `IEnumerable<T> T?.AsEnumerable<T>()`

Converts `T?` into an `IEnumerable<T>` with a single item in case the `T?` has a value. Otherwise the `IEnumerable<T>` will be empty.

```csharp
IEnumerable<int> singleton = Nullable(13).AsEnumerable();
IEnumerable<string> empty = Nullable<string>().AsEnumerable();
```

### `T? T.AsNullable<T>()`

Converts a `T` into a `T?`.

```csharp
string str1 = "hello";
string? str2 = str1.AsNullable();
```

### `T2? T1?.Bind<T1, T2>(Func<T1, T2?> binder)`

Evaluates whether the `T1?` has a value. If so, it is provided to the `binder` function and its result is returned. Otherwise `Bind()` will return `null`.

```csharp
int? ParseInt(string s) => int.TryParse(s, out var i) ? (int?)i : null;

int? num = Nullable("123").Bind(ParseInt);
```

Similar to `Map()` except that `binder` must return a nullable type.

### `T? T?.Filter<T>(Predicate<T> predicate)`

Turns `T?`s that don't satisfy the `predicate` function into `null`s. If `T?` already was `null` it will just be forwarded as is.

```csharp
int? even = Nullable(13).Filter(n => n % 2 == 0);
// `even` will be `null`
```

### `T2? T1?.Map<T1, T2>(Func<T1, T2> mapping)`

Evaluates whether the `T1?` has a value. If so, it is provided to the `mapping` function and its result is returned. Otherwise `Map()` will return `null`.

```csharp
int? succ = Nullable(13).Map(n => n + 1);
```

Similar to `Bind()` except that `mapping` must return a non-nullable type.

### `T? Nullable<T>(T x)`

Creates a nullable type from a value.

```csharp
using static Nullable.Extensions.NullableClass;
using static Nullable.Extensions.NullableStruct;

// ...

string? s = Nullable("hi");
int? i = Nullable(13);
```

Make sure to place the `using static ...` _inside_ your own namespace. Otherwise you will have to specifiy `T` explicitly (e.g. `Nullable<int>(13)`).

### `T? Nullable<T>()`

Creates a `null` of the specified type.

```csharp
using static Nullable.Extensions.NullableClass;
using static Nullable.Extensions.NullableStruct;

// ...

string? s = Nullable<string>();
int? i = Nullable<int>();
```

### `T2? T1?.Select<T1, T2>(Func<T1, T2> mapping)`

Alias for `Map()`. Also enables LINQ's query syntax for `T?`.

```csharp
int? i = from s in Nullable("3")
         select int.Parse(s);
```

### `T3? T1?.SelectMany<T1, T2, T3>(Func<T1, T2?> binder)`

Alias for `Bind()`.

### `T3? T1?.SelectMany<T1, T2, T3>(Func<T1, T2?> binder, Func<T1, T2, T3> mapping)`

Enables LINQ's query syntax for `T?`.

```csharp
int? ParseInt(string s) => int.TryParse(s, out var i) ? (int?)i : null;

int? sum = from s in Nullable("2")
           from i1 in ParseInt(s)
           from i2 in Nullable(3)
           select i1 + i2;
```

### `T2 T1?.Switch<T1, T2>(Func<T1, T2> notNull, Func<T2> isNull)`

Switches on a nullable type and returns the result of one the provided functions. The `notNull` function is executed in case the `T?` is not null. The `isNull` function otherwise.

```csharp
bool success = Nullable("abc").Switch(
    notNull: s => true,
    isNull: () => false);
```

`Switch()` is supposed to be used to terminate a chain of `T?` extension methods. It shouldn't be needed too often, though. Most of the time the null-coalescing operator `??` should be sufficient.

### `T? T?.Tap<T>(Action<T> effect)`

Executes a side-effect in case the `T?` has a value and then returns it unchanged. This works similar to tapping a phone line. Also useful during debugging, because it can be safely added to method chains for additional break points.

```csharp
bool s_was_null = true;
bool i_was_null = true;

string? s = Nullable("hi").Tap(s => s_was_null = false);
int? i = Nullable<int>().Tap(i => i_was_null = false);

// `s_was_null` is now `false`
// `i_was_null` is still `true`
```

### `T? T?.Where<T>(Predicate<T> predicate)`

Alias for `Filter()`. Also enables LINQ's query syntax for `T?`.

```csharp
string msg = from s in Nullable("hi!")
             where s.Length > 0
             select s;
```

## TODO

- add XML documentation
- generate API reference with mddox
