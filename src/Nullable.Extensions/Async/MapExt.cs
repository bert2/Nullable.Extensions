namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class MapExt1 {
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => (await x).Map(mapping);

        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => (await x).Map(mapping);
    }

    public static class MapExt2 {
        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => (await x).Map(mapping);

        public static async Task<T2?> Map<T1, T2>(this Task<T1?> x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => (await x).Map(mapping);
    }
}
