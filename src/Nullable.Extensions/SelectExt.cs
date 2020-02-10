namespace Nullable.Extensions {
    using System;

    public static class SelectExt1 {
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : class
            => x.Map(mapping);

        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : struct
            => x.Map(mapping);
    }

    public static class SelectExt2 {
        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : class
            where T2 : struct
            => x.Map(mapping);

        public static T2? Select<T1, T2>(this T1? x, Func<T1, T2> mapping)
            where T1 : struct
            where T2 : class
            => x.Map(mapping);
    }
}
