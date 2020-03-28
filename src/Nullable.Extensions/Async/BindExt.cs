namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class BindExt {
        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => (await x).Bind(binder);

        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => (await x).Bind(binder);

        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => (await x).Bind(binder);

        public static async Task<T2?> Bind<T1, T2>(this Task<T1?> x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => (await x).Bind(binder);
    }
}
