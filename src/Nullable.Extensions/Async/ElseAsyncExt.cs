namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `ElseAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class ElseAsyncExt {
        /// <summary>Replaces `null` values with the alternative value returned by `onNull()`, but leaves non-`null` values untouched.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="onNull">Used to asynchronously calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` returning `x` when `x` is not `null` and the result of `onNull()` otherwise.</returns>
        public static async Task<T?> ElseAsync<T>(this T? x, Func<Task<T?>> onNull)
            where T : class
            => x ?? await onNull();

        /// <summary>`await`s the given `Task` of type `T?` and calls `ElseAsync(onNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="onNull">Used to asynchronously calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` wrapping the result of `ElseAsync(onNull)`.</returns>
        public static async Task<T?> ElseAsync<T>(this Task<T?> x, Func<Task<T?>> onNull)
            where T : class
            => await (await x).ElseAsync(onNull);

        /// <summary>Replaces `null` values with the alternative value returned by `onNull()`, but leaves non-`null` values untouched.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="onNull">Used to asynchronously calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` returning `x` when `x` is not `null` and the result of `onNull()` otherwise.</returns>
        public static async Task<T?> ElseAsync<T>(this T? x, Func<Task<T?>> onNull)
            where T : struct
            => x ?? await onNull();

        /// <summary>`await`s the given `Task` of type `T?` and calls `ElseAsync(onNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="onNull">Used to asynchronously calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` wrapping the result of `ElseAsync(onNull)`.</returns>
        public static async Task<T?> ElseAsync<T>(this Task<T?> x, Func<Task<T?>> onNull)
            where T : struct
            => await (await x).ElseAsync(onNull);
    }
}
