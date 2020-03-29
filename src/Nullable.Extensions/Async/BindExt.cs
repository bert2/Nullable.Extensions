namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Bind()` extension for `Task`s of type `T?`.</summary>
    public static class BindExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Bind(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Bind(binder)`.</returns>
        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => (await x).Bind(binder);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Bind(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Bind(binder)`.</returns>
        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => (await x).Bind(binder);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Bind(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Bind(binder)`.</returns>
        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => (await x).Bind(binder);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Bind(binder)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="binder">The binding function. Its argument is guaranteed to be not `null`. Its return type should be nullable.</param>
        /// <returns>A `Task` wrapping the result of `Bind(binder)`.</returns>
        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => (await x).Bind(binder);
    }
}
