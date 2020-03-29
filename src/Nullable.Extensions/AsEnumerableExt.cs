namespace Nullable.Extensions {
    using System.Collections.Generic;

    /// <summary>Defines the `AsEnumerable()` extension for `T?`.</summary>
    public static class AsEnumerableExt {
        /// <summary>Turns the nullable type `T?` into an `IEnumerable` of type `T`. The `IEnumerable` will either be empty or contain a single element, depending on whether `x` was `null` or not.</summary>
        /// <param name="x">The nullable value.</param>
        /// <returns>A singleton `IEnumerable` of type `T` when the nullable value `x` is not `null`, and an empty `IEnumerable` otherwise.</returns>
        public static IEnumerable<T> AsEnumerable<T>(this T? x) where T : class {
            if (x != null) yield return x;
        }

        /// <summary>Turns the nullable type `T?` into an `IEnumerable` of type `T`. The `IEnumerable` will either be empty or contain a single element, depending on whether `x` was `null` or not.</summary>
        /// <param name="x">The nullable value.</param>
        /// <returns>A singleton `IEnumerable` of type `T` when the nullable value `x` is not `null`, and an empty `IEnumerable` otherwise.</returns>
        public static IEnumerable<T> AsEnumerable<T>(this T? x) where T : struct {
            if (x.HasValue) yield return x.Value;
        }
    }
}
