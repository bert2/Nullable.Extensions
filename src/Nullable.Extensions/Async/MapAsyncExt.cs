namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class MapAsyncExt1 {
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : class
            => x != null ? await mapping(x) : null;

        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : class
            => await (await x).MapAsync(mapping);

        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? (T2?)await mapping(x.Value) : null;

        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : struct
            => await (await x).MapAsync(mapping);
    }

    public static class MapAsyncExt2 {
        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : struct
            => x != null ? (T2?)await mapping(x) : null;

        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : class
            where T2 : struct
            => await (await x).MapAsync(mapping);

        public static async Task<T2?> MapAsync<T1, T2>(this T1? x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : class
            => x.HasValue ? await mapping(x.Value) : null;

        public static async Task<T2?> MapAsync<T1, T2>(this Task<T1?> x, Func<T1, Task<T2>> mapping)
            where T1 : struct
            where T2 : class
            => await (await x).MapAsync(mapping);
    }
}
