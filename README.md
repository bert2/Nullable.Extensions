# Nullable.Extensions

[![build](https://img.shields.io/appveyor/build/bert2/nullable-extensions/master?logo=appveyor)](https://ci.appveyor.com/project/bert2/nullable-extensions/branch/master) [![tests](https://img.shields.io/appveyor/tests/bert2/nullable-extensions/master?compact_message&logo=appveyor)](https://ci.appveyor.com/project/bert2/nullable-extensions/branch/master) [![coverage](https://img.shields.io/codecov/c/github/bert2/Nullable.Extensions/master?logo=codecov)](https://codecov.io/gh/bert2/Nullable.Extensions) [![CodeFactor](https://www.codefactor.io/repository/github/bert2/nullable.extensions/badge)](https://www.codefactor.io/repository/github/bert2/nullable.extensions) ![last commit](https://img.shields.io/github/last-commit/bert2/Nullable.Extensions/master?logo=github) [![nuget package](https://img.shields.io/nuget/v/Nullable.Extensions.svg?logo=nuget)](https://www.nuget.org/packages/Nullable.Extensions) [![nuget downloads](https://img.shields.io/nuget/dt/Nullable.Extensions?color=blue&logo=nuget)](https://www.nuget.org/packages/Nullable.Extensions)

`Nullable.Extensions` is a set of C# extension methods to help working with nullable types by implementing the [Maybe monad](https://www.dotnetcurry.com/patterns-practices/1510/maybe-monad-csharp) on top of `T?`. This includes nullable value types (NVTs) and nullable reference types (NRTs).

> **Note**\
> I consider this library experimental by now. Due to C#'s somewhat inconsistent implementation of NRTs, using a [dedicated maybe-like type](https://gist.github.com/bert2/eebc3dbb6c38599a041daaaec16467f8) will result in more user-friendly and safer code. [(Read more)](https://gist.github.com/bert2/2413ea125992fe59d66d24238cf9eba7#option-vs-nullable-reference-types)

## Table of contents

- [Prerequisites](#prerequisites)
- [Usage examples](#usage-examples)
- [Working with `Task<T?>`](#working-with-taskt)
- [Known issues](#known-issues)
  * [Fixing "The call is ambiguous between..."](#fixing-the-call-is-ambiguous-between)
  * [Fixing conflicts with LINQ](#fixing-conflicts-with-linq)
- [Method reference](#method-reference)
  * [Core functionality](#core-functionality)
  * [Support](#support)
  * [Utility functions](#utility-functions)

## Prerequisites

- your project's `TargetFramework` must be `netcoreapp3.1` or `netstandard2.1`
- [enabled nullable reference types](https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references#nullable-contexts) (via `<Nullable>enable</Nullable>` in your `.csproj` file or `#nullable enable` in your `.cs` file)
- import the namespaces:

```csharp
// required:
using Nullable.Extensions; // extension methods on `T?`

// optional:
using Nullable.Extensions.Async; // async extension methods on `Task<T?>`
using Nullable.Extensions.Linq; // enables LINQ's query syntax on `T?`

// utility:
using Nullable.Extensions.Util; // Nullable variants of framework functions. This is the way.
using static Nullable.Extensions.Util.TryParseFunctions; // helper functions to try-parse built-in types as `T?`
```

You might encounter problems when you are using the extension methods from the namespaces `Async` or `Linq`. See [the sections below](#fixing-the-call-is-ambiguous-between) on how to resolve those.

The namespace `Nullable.Extensions.Util` is meant for functions that re-implement common framework behavior the "nullable way". For instance, instead of retrieving a value from a dictionary safely via `bool TryGetValue(K, out V)`, its nicer to use `V? TryGetValue(K)`. You feel there is one missing? Got an idea for a useful utility function? Please, let me know by creating an issue or a pull request!

## Usage examples

All examples assume the namespace `Nullable.Extensions` has been imported.

Filtering and parsing nullable user input:

```csharp
int num = GetUserInput() // returns `string?`
    .Filter(s => s.All(char.IsDigit))
    .Filter(s => s.Length < 10)
    .Map(int.Parse)
    ?? throw new Exception("No input given or input was not numeric");
```

With the nullable variant of `int.TryParse()` this can be simplified:

```csharp
using static Nullable.Extensions.Util.TryParseFunctions;

// ...

int num = GetUserInput("abc")
    .Bind(TryParseInt)
    ?? throw new Exception("No input given or input was not numeric");
```

Using `Switch()` to provide a mapping and a default value in one go:

```csharp
int num = GetUserInput() // returns `string?`
    .Bind(TryParseInt)
    .Switch(notNull: n => n - 1, isNull: () => 0);
```

However, I'd prefer using an explicit `Map()` and the null-coalescing operator `??`:

```csharp
int num = GetUserInput()
    .Bind(TryParseInt)
    .Map(n => n - 1)
    ?? 0;
```

With `Switch()` and the `??` operator `null`-value handling can only be done at the end of a chain. Using `Else()`, however, we can also handle `null`s in the middle of a chain and replace them with alternative values:

```csharp
int num = GetUserInput(prompt: "Enter a number:")
    .Bind(TryParseInt)
    .Else(() => GetUserInput(prompt: "A number PLEASE!").Bind(TryParseInt)) // One more chance...
    .Else(() => TryGetRandomNumber()) // If you don't care then I don't care.
    .Map(n => n - 1)
    ?? 0;
```

## Working with `Task<T?>`

The namespace `Nullable.Extensions.Async` contains asynchronous variants of most of the extension methods. Importing them enables the fluent API on `Task<T?>`.

```csharp
using Nullable.Extensions;
using Nullable.Extensions.Async;
using Nullable.Extensions.Util;
using static Nullable.Extensions.Util.TryParseFunctions;

// ...

public async Task<User?> LoadUser(int id) => // ...

string userName = await requestParams // a `Dictionary<string, string>`
    .TryGetValue("userId")
    .Bind(TryParseInt)
    .BindAsync(LoadUser)
    .Map(u => u.Name)
    ?? "n/a";
```

Note that you only have to `await` the result once at the very top of the method chain.

## Known issues

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

### Fixing conflicts with LINQ

When you are using extension methods from `Nullable.Extensions.Linq`, you might occasionally encounter situations where the compiler picks the wrong overload for `Select()`, `Where()`, or `SelectMany()`:

```csharp
var xs = new[] { 1, 2, 3 }.Select(x => x.ToString()); // WARNING CS8634
```

In the above example it was probably intended to use `System.Linq.Enumerable.Select()`, but the compiler chose the `Select()` extension on `T?` instead. A compiler warning might indicate this issue:

> CS8634: The type 'string?' cannot be used as type parameter 'T2' in the generic type or method 'SelectExt1.Select<T1, T2>(T1?, Func<T1, T2>)'. Nullability of type argument 'string?' doesn't match 'class' constraint.

Again, this is also easy to fix by assisting the type inference with an explicit type declaration on the lambda parameter:

```csharp
var xs = new[] { 1, 2, 3 }.Select((int x) => x.ToString()); // no warning and correct `Select()`
```

## Method reference

### Core functionality

#### `T2? T1?.Bind<T1, T2>(Func<T1, T2?> binder)`

Evaluates whether the `T1?` has a value. If so, it is provided to the `binder` function and its result is returned. Otherwise `Bind()` will return `null`.

```csharp
int? ParseInt(string s) => int.TryParse(s, out var i) ? (int?)i : null;

int? num = Nullable("123").Bind(ParseInt);
```

Similar to `Map()` except that `binder` must return a nullable type.

#### `T? T?.Filter<T>(Func<T, bool> predicate)`

Turns `T?`s that don't satisfy the `predicate` function into `null`s. If `T?` already was `null` it will just be forwarded as is.

```csharp
int? even = Nullable(13).Filter(n => n % 2 == 0);
// `even` will be `null`
```

#### `T2? T1?.Map<T1, T2>(Func<T1, T2> mapping)`

Evaluates whether the `T1?` has a value. If so, it is provided to the `mapping` function and its result is returned. Otherwise `Map()` will return `null`.

```csharp
int? succ = Nullable(13).Map(n => n + 1);
```

Similar to `Bind()` except that `mapping` must return a non-nullable type.

### Support

#### `T? T.AsNullable<T>()`

Converts a `T` into a `T?`.

```csharp
string str1 = "hello";
string? str2 = str1.AsNullable();
```

Implemented for completeness. Most of the time the implicit conversions from `T` to `T?` will be sufficient.

#### `T? T?.Else<T>(Func<T?> onNull)`

Evaluates whether the `T?` has a value. If so, it is simply forwarded untouched. When it's `null` the `onNull` function will be evaluated to calculate a replacement value. The result of `onNull()` might also be `null`.

```csharp
string? yourMessage = null;
string? greeting = yourMessage.Else(() => "Hello world!");

int? one = Nullable(1).Else(() => 13);
```

`Else()` is useful when implementing simple error handling. Its advantage over `Switch()` and `??` being that it can be used in the middle a method chain rather than only at the end of one.

#### `T? Nullable<T>(T x)`

Creates a nullable type from a value.

```csharp
using static Nullable.Extensions.NullableClass;
using static Nullable.Extensions.NullableStruct;

// ...

string? s = Nullable("hi");
int? i = Nullable(13);
```

Make sure to place the `using static ...` _inside_ your own namespace. Otherwise you will have to specifiy `T` explicitly (e.g. `Nullable<int>(13)`).

Implemented for completeness. Most of the time the implicit conversions from `T` to `T?` will be sufficient.

#### `T? Nullable<T>()`

Creates a `null` of the specified type.

```csharp
using static Nullable.Extensions.NullableClass;
using static Nullable.Extensions.NullableStruct;

// ...

string? s = Nullable<string>();
int? i = Nullable<int>();
```

Implemented for completeness. Most of the time the explicit and implicit conversions from `null` to `T?` should be sufficient.

#### `T2? T1?.Select<T1, T2>(Func<T1, T2> mapping)`

Alias for `Map()`. Also enables LINQ's query syntax for `T?`.

```csharp
using Nullable.Extensions.Linq;

// ...

int? i = from s in Nullable("3")
         select int.Parse(s);
```

#### `T3? T1?.SelectMany<T1, T2, T3>(Func<T1, T2?> binder)`

Alias for `Bind()`.

#### `T3? T1?.SelectMany<T1, T2, T3>(Func<T1, T2?> binder, Func<T1, T2, T3> mapping)`

Enables LINQ's query syntax for `T?`.

```csharp
using Nullable.Extensions.Linq;

// ...

int? ParseInt(string s) => int.TryParse(s, out var i) ? (int?)i : null;

int? sum = from s in Nullable("2")
           from i1 in ParseInt(s)
           from i2 in Nullable(3)
           select i1 + i2;
```

#### `T2 T1?.Switch<T1, T2>(Func<T1, T2> notNull, Func<T2> isNull)`

Switches on a nullable type and returns the result of one the provided functions. The `notNull` function is executed in case the `T?` is not null. The `isNull` function otherwise.

```csharp
bool success = Nullable("abc").Switch(
    notNull: s => true,
    isNull: () => false);
```

`Switch()` is supposed to be used to terminate a chain of `T?` extension methods. It shouldn't be needed too often, though. Most of the time the null-coalescing operator `??` should be sufficient.

#### `T? T?.Tap<T>(Action<T> effect)`

Executes a side-effect in case the `T?` has a value and then returns it unchanged. This works similar to tapping a phone line. Also useful during debugging, because it can be safely added to method chains for additional break points.

```csharp
bool s_was_null = true;
bool i_was_null = true;

string? s = Nullable("hi").Tap(s => s_was_null = false);
int? i = Nullable<int>().Tap(i => i_was_null = false);

// `s_was_null` is now `false`
// `i_was_null` is still `true`
```

#### `IEnumerable<T> T?.ToEnumerable<T>()`

Converts `T?` into an `IEnumerable<T>` with a single item in case the `T?` has a value. Otherwise the `IEnumerable<T>` will be empty.

```csharp
IEnumerable<int> singleton = Nullable(13).ToEnumerable();
IEnumerable<string> empty = Nullable<string>().ToEnumerable();
```

#### `T? IEnumerable<T>.ToNullable<T>()`

Converts a singleton `IEnumerable<T>` into a `T?` that is `null` case the `IEnumerable<T>` is empty. Otherwise the result will be the `IEnumerable<T>`'s only item. Throws when the `IEnumerable<T>` contains more than one item.

```csharp
int? nullValue = Enumerable.Empty<int>().ToNullable();
string? nonNullValue = new[] { "hi" }.ToNullable();
new[] { 1, 2, 3 }.ToNullable(); // throws `InvalidOperationException`
```

#### `T? T?.Where<T>(Func<T, bool> predicate)`

Alias for `Filter()`. Also enables LINQ's query syntax for `T?`.

```csharp
using Nullable.Extensions.Linq;

// ...

string msg = from s in Nullable("hi!")
             where s.Length > 0
             select s;
```

### Utility functions

Got an idea for a useful utility function? Please, let me know by creating an issue or a pull request!

#### `T? IDictionary<K, V>.TryGetValue<K, V>(K key)`

Gets the value associated with the specified key, or `null` if the key is not present.

```csharp
using Nullable.Extensions.Util;

// ...

var nums = new Dictionary<string, int> { ["lucky"] = 13 };
var luckyNumber = nums.TryGetValue("lucky");
var nullValue = nums.TryGetValue("unlucky");
```

#### `T? TryParse*(string value)`

A family of functions for safely parsing strings. Can be used as a replacement for `bool int.TryParse(string, out int)` and all its variants.

The following types are supported: `bool`, `byte`, `sbyte`, `char`, `decimal`, `double`, `float`, `int`, `uint`, `long`, `ulong`, `short`, `ushort`, `DateTime`, `DateTimeOffset`, `TimeSpan`, and `Guid`.

```csharp
using static Nullable.Extensions.Util.TryParseFunctions;

// ...

int? one = TryParseInt("1");
ulong? manyNines = TryParseULong("9999999999999999999");
TimeSpan? time = TryParseTimeSpan("13:12");
DateTime? nullValue = TryParseDateTime("yesterday");
```
