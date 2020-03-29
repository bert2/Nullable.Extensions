namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `Tap()` extension for `Task`s of type `T?`.</summary>
    public static class TapExt {
        /// <summary>`await`s the given `Task` of type `T?` and calls `Tap(effect)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="effect">The side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `Tap(effect)`.</returns>
        public static async Task<T?> Tap<T>(this Task<T?> x, Action<T> effect)
            where T : class
            => (await x).Tap(effect);

        /// <summary>`await`s the given `Task` of type `T?` and calls `Tap(effect)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="effect">The side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `Tap(effect)`.</returns>
        public static async Task<T?> Tap<T>(this Task<T?> x, Action<T> effect)
            where T : struct
            => (await x).Tap(effect);
    }
}
