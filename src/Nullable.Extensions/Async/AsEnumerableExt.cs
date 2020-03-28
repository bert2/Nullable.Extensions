namespace Nullable.Extensions.Async {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class AsEnumerableExt {
        public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<T?> x)
            where T : class
            => (await x).AsEnumerable();

        public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<T?> x)
            where T : struct
            => (await x).AsEnumerable();
    }
}
