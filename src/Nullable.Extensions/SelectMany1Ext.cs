namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `SelectMany()` extension for `T?`.</summary>
    public static class SelectMany1Ext {
        /// <summary>Alias for `Bind()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified binding. The binding function `binder` should return a nullable type. Use `Select()`/`Map()` in case `binder` returns a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>The result of `binding` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => x.Bind(binder);

        /// <summary>Alias for `Bind()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified binding. The binding function `binder` should return a nullable type. Use `Select()`/`Map()` in case `binder` returns a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>The result of `binding` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => x.Bind(binder);

        /// <summary>Alias for `Bind()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified binding. The binding function `binder` should return a nullable type. Use `Select()`/`Map()` in case `binder` returns a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>The result of `binding` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => x.Bind(binder);

        /// <summary>Alias for `Bind()`. Turns nullable values of type `T1` into nullable values of type `T2` using the specified binding. The binding function `binder` should return a nullable type. Use `Select()`/`Map()` in case `binder` returns a non-nullable type.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>The result of `binding` applied to the value of `x` when `x` is not `null`, and `null` otherwise.</returns>
        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => x.Bind(binder);
    }
}
