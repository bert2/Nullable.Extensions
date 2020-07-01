namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Else()` extension for `Task`s of type `T?`.</summary>
    public static class ElseExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Else(onNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="onNull">Used to calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` wrapping the result of `Else(onNull)`.</returns>
        public static async Task<T?> Else<T>(this Task<T?> x, Func<T?> onNull)
            where T : class
            => (await x).Else(onNull);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Else(onNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="onNull">Used to calculate a replacement value when `x` is `null`.</param>
        /// <returns>A `Task` wrapping the result of `Else(onNull)`.</returns>
        public static async Task<T?> Else<T>(this Task<T?> x, Func<T?> onNull)
            where T : struct
            => (await x).Else(onNull);
    }
}
