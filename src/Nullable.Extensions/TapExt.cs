namespace Nullable.Extensions {
    using System;

    public static class TapExt {
        public static T? Tap<T>(this T? x, Action<T> effect) where T : class {
            if (x != null) effect(x);
            return x;
        }

        public static T? Tap<T>(this T? x, Action<T> effect) where T : struct {
            if (x.HasValue) effect(x.Value);
            return x;
        }
    }
}
