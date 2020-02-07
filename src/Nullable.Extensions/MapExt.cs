namespace Nullable.Extensions {
    using System;

    public static class MapExt1 {
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => x != null ? mapping(x) : null;

        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => x.HasValue ? (T2?)mapping(x.Value) : null;
    }

    public static class MapExt2 {
        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => x != null ? (T2?)mapping(x) : null;

        public static T2? Map<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => x.HasValue ? mapping(x.Value) : null;
    }
}
