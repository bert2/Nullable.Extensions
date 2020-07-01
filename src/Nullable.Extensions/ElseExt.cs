namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Else()` extension for `T?`.</summary>
    public static class ElseExt {
        /// <summary>Replaces `null` values with the alternative value returned by `onNull()`, but leaves non-`null` values untouched.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="onNull">Used to calculate a replacement value when `x` is `null`.</param>
        /// <returns>Returns `x` when `x` is not `null` and the result of `onNull()` otherwise.</returns>
        public static T? Else<T>(this T? x, Func<T?> onNull)
            where T : class
            => x ?? onNull();

        /// <summary>Replaces `null` values with the alternative value returned by `onNull()`, but leaves non-`null` values untouched.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="onNull">Used to calculate a replacement value when `x` is `null`.</param>
        /// <returns>Returns `x` when `x` is not `null` and the result of `onNull()` otherwise.</returns>
        public static T? Else<T>(this T? x, Func<T?> onNull)
            where T : struct
            => x ?? onNull();
    }
}
