namespace Nullable.Extensions {
    using System;

    /// <summary>Defines the `Tap()` extension for `T?`.</summary>
    public static class TapExt {
        /// <summary>Executes a side effect when the nullable value is not `null`.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="effect">The side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>The nullable input value unchanged.</returns>
        public static T? Tap<T>(this T? x, Action<T> effect) where T : class {
            if (x != null) effect(x);
            return x;
        }

        /// <summary>Executes a side effect when the nullable value is not `null`.</summary>
        /// <param name="x">The nullable value.</param>
        /// <param name="effect">The side effect to execute. Its argument is guaranteed to be not `null`.</param>
        /// <returns>The nullable input value unchanged.</returns>
        public static T? Tap<T>(this T? x, Action<T> effect) where T : struct {
            if (x.HasValue) effect(x.Value);
            return x;
        }
    }
}
