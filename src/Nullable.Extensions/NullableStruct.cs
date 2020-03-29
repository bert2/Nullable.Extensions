namespace Nullable.Extensions {
    using System.Runtime.CompilerServices;

    /// <summary>Defines static helper methods to create nullable values.</summary>
    public static class NullableStruct {
        /// <summary>Turns a value of type `T` into the nullable type `T?`.</summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input value as `T?`.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? AsNullable<T>(this T x) where T : struct => x;

        /// <summary>Turns a value of type `T` into the nullable type `T?`.</summary>
        /// <param name="x">The input value.</param>
        /// <returns>The input value as `T?`.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? Nullable<T>(T x) where T : struct => x;

        /// <summary>Creates a `null` of type `T?`.</summary>
        /// <returns>Returns `null` as `T?`.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? Nullable<T>() where T : struct => null;
    }
}
