namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class TapAsyncExt {
        public static async Task<T?> TapAsync<T>(this T? x, Func<T, Task> effect) where T : class {
            if (x != null) await effect(x);
            return x;
        }

        public static async Task<T?> TapAsync<T>(this Task<T?> x, Func<T, Task> effect)
            where T : class
            => await (await x).TapAsync(effect);

        public static async Task<T?> TapAsync<T>(this T? x, Func<T, Task> effect) where T : struct {
            if (x.HasValue) await effect(x.Value);
            return x;
        }

        public static async Task<T?> TapAsync<T>(this Task<T?> x, Func<T, Task> effect)
            where T : struct
            => await (await x).TapAsync(effect);
    }
}
