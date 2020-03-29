namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Map()` extension for `Task`s of type `T?`.</summary>
    public static class MapExt1 {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Map(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Map(mapping)`.</returns>
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => (await x).Map(mapping);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Map(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Map(mapping)`.</returns>
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => (await x).Map(mapping);
    }

    /// <summary>Defines the `Map()` extension for `Task`s of type `T?`.</summary>
    public static class MapExt2 {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Map(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Map(mapping)`.</returns>
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => (await x).Map(mapping);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Map(mapping)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="mapping">The mapping function. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Map(mapping)`.</returns>
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => (await x).Map(mapping);
    }
}
