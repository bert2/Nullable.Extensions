namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class FilterExt {
        public static async Task<T?> Filter<T>(this Task<T?> x, Func<T, bool> predicate)
            where T : class
            => (await x).Filter(predicate);

        public static async Task<T?> Filter<T>(this Task<T?> x, Func<T, bool> predicate)
            where T : struct
            => (await x).Filter(predicate);
    }
}
