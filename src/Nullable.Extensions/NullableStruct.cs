namespace Nullable.Extensions {
    public static class NullableStruct {
        public static T? AsNullable<T>(this T x) where T : struct => x;

        public static T? Nullable<T>(T x) where T : struct => x;

        public static T? Nullable<T>() where T : struct => null;
    }
}
