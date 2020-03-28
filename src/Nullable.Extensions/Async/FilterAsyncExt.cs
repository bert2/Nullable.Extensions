namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class FilterAsyncExt {
        public static async Task<T?> FilterAsync<T>(this T? x, Func<T, Task<bool>> predicate)
            where T : class
            => x != null && await predicate(x) ? x : null;

        public static async Task<T?> FilterAsync<T>(this Task<T?> x, Func<T, Task<bool>> predicate)
            where T : class
            => await (await x).FilterAsync(predicate);

        public static async Task<T?> FilterAsync<T>(this T? x, Func<T, Task<bool>> predicate)
            where T : struct
            => x.HasValue && await predicate(x.Value) ? x : null;

        public static async Task<T?> FilterAsync<T>(this Task<T?> x, Func<T, Task<bool>> predicate)
            where T : struct
            => await (await x).FilterAsync(predicate);
    }
}
