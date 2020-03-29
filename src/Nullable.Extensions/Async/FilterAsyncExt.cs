namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `FilterAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class FilterAsyncExt {
        /// <summary>Turns all nullable values into `null` that don't satisfy the specified asynchonous predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The asynchonous filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` returning `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns a `Task` returning `x` otherwise.</returns>
        public static async Task<T?> FilterAsync<T>(this T? x, Func<T, Task<bool>> predicate)
            where T : class
            => x != null && await predicate(x) ? x : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `FilterAsync(predicate)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="predicate">The asynchronous filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `FilterAsync(predicate)`.</returns>
        public static async Task<T?> FilterAsync<T>(this Task<T?> x, Func<T, Task<bool>> predicate)
            where T : class
            => await (await x).FilterAsync(predicate);

        /// <summary>Turns all nullable values into `null` that don't satisfy the specified asynchonous predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The asynchonous filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` returning `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns a `Task` returning `x` otherwise.</returns>
        public static async Task<T?> FilterAsync<T>(this T? x, Func<T, Task<bool>> predicate)
            where T : struct
            => x.HasValue && await predicate(x.Value) ? x : null;

        /// <summary>`await`s the given `Task` of type `T?` and calls `FilterAsync(predicate)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="predicate">The asynchronous filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `FilterAsync(predicate)`.</returns>
        public static async Task<T?> FilterAsync<T>(this Task<T?> x, Func<T, Task<bool>> predicate)
            where T : struct
            => await (await x).FilterAsync(predicate);
    }
}
