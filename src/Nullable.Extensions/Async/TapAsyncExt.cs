namespace Nullable.Extensions.Async {
    using System;
    using System.Threading.Tasks;

    /// <summary>Defines the `TapAsync()` extension for `T?` and `Task`s of type `T?`.</summary>
    public static class TapAsyncExt {
        /// <summary>Executes an asychronous side effect when the nullable value is not `null`.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="effect">The asychronous side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` returning the nullable input value unchanged.</returns>
        public static async Task<T?> TapAsync<T>(this T? x, Func<T, Task> effect) where T : class {
            if (x != null) await effect(x);
            return x;
        }

        /// <summary>`await`s the given `Task` of type `T?` and calls `TapAsync(effect)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="effect">The asychronous side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `TapAsync(effect)`.</returns>
        public static async Task<T?> TapAsync<T>(this Task<T?> x, Func<T, Task> effect)
            where T : class
            => await (await x).TapAsync(effect);

        /// <summary>Executes an asychronous side effect when the nullable value is not `null`.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="effect">The asychronous side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` returning the nullable input value unchanged.</returns>
        public static async Task<T?> TapAsync<T>(this T? x, Func<T, Task> effect) where T : struct {
            if (x.HasValue) await effect(x.Value);
            return x;
        }

        /// <summary>`await`s the given `Task` of type `T?` and calls `TapAsync(effect)` on the returned nullable value.</summary>
        /// <param name="x">The nullable value `Task`.</param>
        /// <param name="effect">The asychronous side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>A `Task` wrapping the result of `TapAsync(effect)`.</returns>
        public static async Task<T?> TapAsync<T>(this Task<T?> x, Func<T, Task> effect)
            where T : struct
            => await (await x).TapAsync(effect);
    }
}
