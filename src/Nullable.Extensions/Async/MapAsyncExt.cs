namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `MapAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class MapAsyncExt1 {
        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous mapping. The mapping function should not return a `Task` of a nullable type; use `BindAsync()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` returning the result of `mapping` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : class
            => x != null ? await mapping(x) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `MapAsync(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `MapAsync(mapping)`.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : class
            => await (await x).MapAsync(mapping);

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous mapping. The mapping function should not return a `Task` of a nullable type; use `BindAsync()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` returning the result of `mapping` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? (T2?)await mapping(x.Value) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `MapAsync(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `MapAsync(mapping)`.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : struct
            => await (await x).MapAsync(mapping);
    }

    /// <summary>Defines the `MapAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class MapAsyncExt2 {
        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous mapping. The mapping function should not return a `Task` of a nullable type; use `BindAsync()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` returning the result of `mapping` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : struct
            => x != null ? (T2?)await mapping(x) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `MapAsync(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `MapAsync(mapping)`.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : struct
            => await (await x).MapAsync(mapping);

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous mapping. The mapping function should not return a `Task` of a nullable type; use `BindAsync()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` returning the result of `mapping` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : class
            => x.HasValue ? await mapping(x.Value) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `MapAsync(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The asynchronous mapping function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `MapAsync(mapping)`.</returns>
        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : class
            => await (await x).MapAsync(mapping);
    }
}
