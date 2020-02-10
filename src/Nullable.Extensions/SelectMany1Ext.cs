namespace Nullable.Extensions {
    using System;

    public static class SelectMany1Ext {
        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => x.Bind(binder);

        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => x.Bind(binder);

        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => x.Bind(binder);

        public static T2? SelectMany<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => x.Bind(binder);
    }
}
