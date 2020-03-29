namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `BindAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class BindAsyncExt {
        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous binding. The binding function `binder` should return a `Task` of a nullable type. Use `MapAsync()` in case `binder` returns a `Task` of a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` returning the result of `binding` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : class
            => x != null ? await binder(x) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `BindAsync(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `BindAsync(binder)`.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : class
            => await (await x).BindAsync(binder);

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous binding. The binding function `binder` should return a `Task` of a nullable type. Use `MapAsync()` in case `binder` returns a `Task` of a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` returning the result of `binding` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? await binder(x.Value) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `BindAsync(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `BindAsync(binder)`.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : struct
            => await (await x).BindAsync(binder);

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous binding. The binding function `binder` should return a `Task` of a nullable type. Use `MapAsync()` in case `binder` returns a `Task` of a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` returning the result of `binding` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : struct
            => x != null ? await binder(x) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `BindAsync(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `BindAsync(binder)`.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : struct
            => await (await x).BindAsync(binder);

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified asynchronous binding. The binding function `binder` should return a `Task` of a nullable type. Use `MapAsync()` in case `binder` returns a `Task` of a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` returning the result of `binding` applied to the value of `x` when `x` is not `null`, and a `Task` returning `null` otherwise.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : class
            => x.HasValue ? await binder(x.Value) : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `BindAsync(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The asynchronous binding function. Its argument is guaranteed to be not `null`. The type of its returned `Task` should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `BindAsync(binder)`.</returns>
        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : class
            => await (await x).BindAsync(binder);
    }
}
