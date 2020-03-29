namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Filter()` extension for `T?`.</summary>
    public static class FilterExt {
        /// <summary>Turns all nullable values into `null` that don't satisfy the specified predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>Returns `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns `x` otherwise.</returns>
        public static T? Filter<T>(this T? x, Func<T, bool> predicate)
            where T : class
            => x != null && predicate(x) ? x : null;

        /// <summary>Turns all nullable values into `null` that don't satisfy the specified predicate.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>Returns `null` when `x` is `null` or when `predicate` returns `false` for the value of `x`. Returns `x` otherwise.</returns>
        public static T? Filter<T>(this T? x, Func<T, bool> predicate)
            where T : struct
            => x.HasValue && predicate(x.Value) ? x : null;
    }
}
