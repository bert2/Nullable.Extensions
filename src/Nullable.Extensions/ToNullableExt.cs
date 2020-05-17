namespace Nullable.Extensions {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>Defines the `ToNullable()` extension for `T?`.</summary>
    public static class ToNullableExt1 {
        /// <summary>Turns a singleton `IEnumerable` of type `T` into the nullable type `T?`. The result will either be `null` or the item of the `IEnumerable`, depending on whether `xs` was empty or not. Throws when `xs` contains more than one element.</summary>
        /// <param name="xs">The singleton `IEnumerable`.</param>
        /// <returns>Returns `null` when `xs` is empty, and `xs`'s item otherwise.</returns>
        public static T? ToNullable<T>(this IEnumerable<T> xs)
            where T : class
            => xs.Any() ? xs.Single() : null;
    }

    /// <summary>Defines the `ToNullable()` extension for `T?`.</summary>
    public static class ToNullableExt2 {
        /// <summary>Turns a singleton `IEnumerable` of type `T` into the nullable type `T?`. The result will either be `null` or the item of the `IEnumerable`, depending on whether `xs` was empty or not. Throws when `xs` contains more than one element.</summary>
        /// <param name="xs">The singleton `IEnumerable`.</param>
        /// <returns>Returns `null` when `xs` is empty, and `xs`'s item otherwise.</returns>
        public static T? ToNullable<T>(this IEnumerable<T> xs)
            where T : struct
            => xs.Any() ? xs.Single() : (T?)null;
    }
}
