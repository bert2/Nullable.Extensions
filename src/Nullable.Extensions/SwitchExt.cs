namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Switch()` extension for `T?`.</summary>
    public static class SwitchExt {
        /// <summary>Switches on a nullable value. Executes the given function `notNull` if `x` is not `null`, and `isNull` otherwise. Should not be needed often, because the null-coalescing operator `??` is almost always sufficient.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="notNull">The handler function for the not `null` case. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <param name="isNull">The handler function for the `null` case.</param>
        /// <returns>The result of `notNull` applied to the value of `x` when `x` is not `null`, and the result of `isNull` otherwise.</returns>
        public static T2 Switch<T1, T2>(this T1? x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : class
            => x != null ? notNull(x) : isNull();

        /// <summary>Switches on a nullable value. Executes the given function `notNull` if `x` is not `null`, and `isNull` otherwise. Should not be needed often, because the null-coalescing operator `??` is almost always sufficient.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="notNull">The handler function for the not `null` case. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <param name="isNull">The handler function for the `null` case.</param>
        /// <returns>The result of `notNull` applied to the value of `x` when `x` is not `null`, and the result of `isNull` otherwise.</returns>
        public static T2 Switch<T1, T2>(this T1? x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : struct
            => x.HasValue ? notNull(x.Value) : isNull();
    }
}
