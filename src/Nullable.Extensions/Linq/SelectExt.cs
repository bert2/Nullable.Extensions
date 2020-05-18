namespace Nullable.Extensions.Linq {
    using System;

    /// <summary>Defines the `Select()` extension for `T?`.</summary>
    public static class SelectExt1 {
        /// <summary>Alias for `Map()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `SelectMany()`/`Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => x.Map(mapping);

        /// <summary>Alias for `Map()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `SelectMany()`/`Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => x.Map(mapping);
    }

    /// <summary>Defines the `Select()` extension for `T?`.</summary>
    public static class SelectExt2 {
        /// <summary>Alias for `Map()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `SelectMany()`/`Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => x.Map(mapping);

        /// <summary>Alias for `Map()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified mapping. The mapping function should not return a nullable type; use `SelectMany()`/`Bind()` in such scenarios instead.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => x.Map(mapping);
    }
}
