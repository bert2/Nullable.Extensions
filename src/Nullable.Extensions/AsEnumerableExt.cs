namespace Nullable.Extensions {
    using System.Collections.Generic;

    public static class AsEnumerableExt {
        public static IEnumerable<T> AsEnumerable<T>(this T? x) where T : class {
            if (x != null) yield return x;
        }

        public static IEnumerable<T> AsEnumerable<T>(this T? x) where T : struct {
            if (x.HasValue) yield return x.Value;
        }
    }
}
