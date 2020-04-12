namespace Nullable.Extensions.Linq {
    using System;

    /// <summary>Defines the `SelectMany()` extension for `T?`.</summary>
    public static class SelectMany2Ext1 {
        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : class
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : class
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : struct
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));
    }

    /// <summary>Defines the `SelectMany()` extension for `T?`.</summary>
    public static class SelectMany2Ext2 {
        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : class
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : struct
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : class
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        /// <summary>Turns a nullable value of type `T1` into a nullable value of type `T2` using the specified binding and then applies the mapping function to both the values. Enables LINQ's query syntax.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// /// <param name="mapping">The mapping function. Its two arguments are guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>The result of `mapping` applied to both the value of `x` and the result of `binding` applied to the value of `x`. Returns `null` when `x` is `null` or `binding` returned `null`.</returns>
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : struct
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));
    }
}
