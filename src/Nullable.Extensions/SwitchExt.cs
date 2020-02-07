namespace Nullable.Extensions {
    using System;

    public static class SwitchExt {
        public static T2 Switch<T1, T2>(this T1? x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : class
            => x != null ? notNull(x) : isNull();

        public static T2 Switch<T1, T2>(this T1? x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : struct
            => x.HasValue ? notNull(x.Value) : isNull();
    }
}
