namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class BindAsyncExt {
        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : class
            => x != null ? await binder(x) : null;

        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : class
            => await (await x).BindAsync(binder);

        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? await binder(x.Value) : null;

        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : struct
            => await (await x).BindAsync(binder);

        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : struct
            => x != null ? await binder(x) : null;

        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : class
            where T2 : struct
            => await (await x).BindAsync(binder);

        public static async Task<T2?> BindAsync<T1, T2>(this T1? x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : class
            => x.HasValue ? await binder(x.Value) : null;

        public static async Task<T2?> BindAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2?>> binder)
            where T1 : struct
            where T2 : class
            => await (await x).BindAsync(binder);
    }
}
