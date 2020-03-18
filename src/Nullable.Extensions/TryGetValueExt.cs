namespace Nullable.Extensions {
    using System.Collections.Generic;

    public static class TryGetValueExt1 {
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : class
            => dict.TryGetValue(key, out var value) ? value : null;
    }

    public static class TryGetValueExt2 {
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : struct
            => dict.TryGetValue(key, out var value) ? (TValue?)value : null;
    }
}
