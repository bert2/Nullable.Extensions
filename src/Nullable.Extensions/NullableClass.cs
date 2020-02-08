namespace Nullable.Extensions {
    public static class NullableClass {
        public static T? AsNullable<T>(this T x) where T : class => x;

        public static T? Nullable<T>(T x) where T : class => x;

        public static T? Nullable<T>() where T : class => null;
    }
}
