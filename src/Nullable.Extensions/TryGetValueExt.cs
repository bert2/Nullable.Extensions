namespace Nullable.Extensions {
    using System.Collections.Generic;

    public static class TryGetValueExt {
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : class
            => dict.TryGetValue(key, out var value) ? value : null;
    }
}
