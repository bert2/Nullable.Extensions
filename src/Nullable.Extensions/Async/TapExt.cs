namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class TapExt {
        public static async Task<T?> Tap<T>(this Task<T?> x, Action<T> effect)
            where T : class
            => (await x).Tap(effect);

        public static async Task<T?> Tap<T>(this Task<T?> x, Action<T> effect)
            where T : struct
            => (await x).Tap(effect);
    }
}
