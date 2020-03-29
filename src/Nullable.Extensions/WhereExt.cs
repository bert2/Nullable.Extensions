namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Where()` extension for `T?`.</summary>
    public static class WhereExt {
        /// <summary>Alias for `Filter()`. Turns all nullable values into `null` that don't satisfy the specified predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>Returns `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns `x` otherwise.</returns>
        public static T? Where<T>(this T? x, Func<T, bool> predicate)
            where T : class
            => x.Filter(predicate);

        /// <summary>Alias for `Filter()`. Turns all nullable values into `null` that don't satisfy the specified predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>Returns `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns `x` otherwise.</returns>
        public static T? Where<T>(this T? x, Func<T, bool> predicate)
            where T : struct
            => x.Filter(predicate);
    }
}
