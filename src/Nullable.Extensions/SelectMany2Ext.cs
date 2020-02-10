namespace Nullable.Extensions {
    using System;

    public static class SelectMany2Ext1 {
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : class
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : struct
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : class
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : struct
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));
    }

    public static class SelectMany2Ext2 {
        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : class
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : class
            where T2 : struct
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : class
            where T3 : struct
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));

        public static T3? SelectMany<T1, T2, T3>(this T1? x, Func<T1, T2?> binder, Func<T1, T2, T3> mapping)
            where T1 : struct
            where T2 : struct
            where T3 : class
            => x.Bind(x1 => binder(x1).Map(x2 => mapping(x1, x2)));
    }
}
