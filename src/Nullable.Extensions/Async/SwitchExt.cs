namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Switch()` extension for `Task`s of type `T?`.</summary>
    public static class SwitchExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Switch(notNull, isNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="notNull">The handler function for the not `null` case. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <param name="isNull">The handler function for the `null` case.</param>
        /// <returns>A `Task` wrapping the result of `Switch(notNull, isNull)`.</returns>
        public static async Task<T2> Switch<T1, T2>(this Task<T1?> x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : class
            => (await x).Switch(notNull, isNull);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Switch(notNull, isNull)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="notNull">The handler function for the not `null` case. Its argument is guaranteed to be not `null`. Its return type should not be nullable.</param>
        /// <param name="isNull">The handler function for the `null` case.</param>
        /// <returns>A `Task` wrapping the result of `Switch(notNull, isNull)`.</returns>
        public static async Task<T2> Switch<T1, T2>(this Task<T1?> x, Func<T1, T2> notNull, Func<T2> isNull)
            where T1 : struct
            => (await x).Switch(notNull, isNull);
    }
}
