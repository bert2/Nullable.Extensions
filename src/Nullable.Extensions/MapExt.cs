namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Map()` extension for `T?`.</summary>
    public static class MapExt1 {
        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => x != null ? mapping(x) : null;

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? (T2?)mapping(x.Value) : null;
    }

    /// <summary>Defines the `Map()` extension for `T?`.</summary>
    public static class MapExt2 {
        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => x != null ? (T2?)mapping(x) : null;

        /// <summary>Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => x.HasValue ? mapping(x.Value) : null;
    }
}
