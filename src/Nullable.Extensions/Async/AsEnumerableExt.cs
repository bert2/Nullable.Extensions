namespace Nullable.Extensions.Async {
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Defines the `AsEnumerable()` extension for `Task`s of type `T?`.</summary>
    public static class AsEnumerableExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `AsEnumerable()` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <returns>A `Task` wrapping the result of `AsEnumerable()`.</returns>
        public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<T?> x)
            where T : class
            => (await x).AsEnumerable();

        /// <summary>`await`s the given `Task` of type `T?` and calls `AsEnumerable()` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <returns>A `Task` wrapping the result of `AsEnumerable()`.</returns>
        public static async Task<IEnumerable<T>> AsEnumerable<T>(this Task<T?> x)
            where T : struct
            => (await x).AsEnumerable();
    }
}
