namespace Nullable.Extensions.Async {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Defines the `ToEnumerable()` extension for `Task`s of type `T?`.</summary>
    public static class ToEnumerableExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `ToEnumerable()` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <returns>A `Task` wrapping the result of `ToEnumerable()`.</returns>
        public static async Task<IEnumerable<T>> ToEnumerable<T>(this Task<T?> x)
            where T : class
            => (await x).ToEnumerable();

        /// <summary>`await`s the given `Task` of type `T?` and calls `ToEnumerable()` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <returns>A `Task` wrapping the result of `ToEnumerable()`.</returns>
        public static async Task<IEnumerable<T>> ToEnumerable<T>(this Task<T?> x)
            where T : struct
            => (await x).ToEnumerable();
    }
}
