namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Filter()` extension for `Task`s of type `T?`.</summary>
    public static class FilterExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Filter(predicate)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `Filter(predicate)`.</returns>
        public static async Task<T?> Filter<T>(this Task<T?> x, Func<T, bool> predicate)
            where T : class
            => (await x).Filter(predicate);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Filter(predicate)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="predicate">The filter function. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `Filter(predicate)`.</returns>
        public static async Task<T?> Filter<T>(this Task<T?> x, Func<T, bool> predicate)
            where T : struct
            => (await x).Filter(predicate);
    }
}
