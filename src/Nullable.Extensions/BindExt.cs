namespace Nullable.Extensions {
    using System;

    public static class BindExt1 {
        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : class
            => x != null ? binder(x) : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? binder(x.Value) : null;
    }

    public static class BindExt2 {
        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : class
            where T2 : struct
            => x != null ? binder(x) : null;

        public static T2? Bind<T1, T2>(this T1? x, Func<T1, T2?> binder)
            where T1 : struct
            where T2 : class
            => x.HasValue ? binder(x.Value) : null;
    }
}
