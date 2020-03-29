namespace Nullable.Extensions {
    using System;

    public static class WhereExt {
        public static T? Where<T>(this T? x, Func<T, bool> predicate)
            where T : class
            => x.Filter(predicate);

        public static T? Where<T>(this T? x, Func<T, bool> predicate)
            where T : struct
            => x.Filter(predicate);
    }
}
