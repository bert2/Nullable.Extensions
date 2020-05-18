namespace Nullable.Extensions.Util {
    using System.Collections.Generic;

    /// <summary>Defines a helper method to safely retrieve values by key from an `IDictionary`.</summary>
    public static class TryGetValueExt1 {
        /// <summary>Gets the value associated with the specified key, or `null` if the key is not present.</summary>
        /// <param name="dict">The dictionary.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The associated value if the `IDictionary` contains an element with the specified key; otherwise, `null`.</returns>
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : class
            => dict.TryGetValue(key, out var value) ? value : null;
    }

    /// <summary>Defines a helper method to safely retrieve values by key from an `IDictionary`.</summary>
    public static class TryGetValueExt2 {
        /// <summary>Gets the value associated with the specified key, or `null` if the key is not present.</summary>
        /// <param name="dict">The dictionary.</param>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The associated value if the `IDictionary` contains an element with the specified key; otherwise, `null`.</returns>
        public static TValue? TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key)
            where TValue : struct
            => dict.TryGetValue(key, out var value) ? (TValue?)value : null;
    }
}
