namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    public static class SwitchExt {
        public static async Task<T2> Switch<T1, T2>(this Task<T1?> x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : class
            => (await x).Switch(notNull, isNull);

        public static async Task<T2> Switch<T1, T2>(this Task<T1?> x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : struct
            => (await x).Switch(notNull, isNull);
    }
}
