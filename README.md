# Nullable.Extensions

[![Build status](https://ci.appveyor.com/api/projects/status/4crxb1fq4hju2bne?svg=true)](https://ci.appveyor.com/project/bert2/nullable-extensions) [![NuGet](https://img.shields.io/nuget/v/Nullable.Extensions.svg)](https://www.nuget.org/packages/Nullable.Extensions)

`Nullable.Extensions` is a set of C# extension methods to help working with nullable types by implementing the [Maybe monad](https://www.dotnetcurry.com/patterns-practices/1510/maybe-monad-csharp) on top of `T?`. This includes nullable value types (`Nullable<T>`s or NVTs) and nullable reference types (NRTs).

## Prerequisites

- enabled nullable reference types (via `<Nullable>enable</Nullable>` in your `.csproj` file or `#nullable enable` in your `.cs` file)
- C# 8.0, dotnet core 3.1
- import the required namespaces:

```csharp
using Nullable.Extensions; // extension methods

// optional:
using static Nullable.Extensions.NullableClass; // factory method for NRTs
using static Nullable.Extensions.NullableStruct; // factory method for NVTs
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
int? ParseInt(string s) => int.TryParse(s, out var i) ? (int?)i : null;

int num = Nullable("abc")
    .Bind(ParseInt)
    ?? throw new Exception("No input given or input was not numeric");
```

```csharp
int num = GetUserInput() // returns `string?`
    .Bind(ParseInt)
    .Switch(notNull: n => n - 1, isNull: () => 0);
```

```csharp
int num = "123"
    .AsNullable()
    .Bind(ParseInt)
    .Map(n => n - 1)
    ?? 0;
```

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
int? sum = from s in Nullable("2")
           from i in Nullable(3)
           select int.Parse(s) + i;
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

## TODO

- add XML documentation
- add async overloads
