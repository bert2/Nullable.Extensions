﻿namespace Nullable.Extensions {
    using System;

    public static class FilterExt {
        public static T? Filter<T>(this T? x, Predicate<T> predicate)
            where T : class
            => x != null && predicate(x) ? x : null;

        public static T? Filter<T>(this T? x, Predicate<T> predicate)
            where T : struct
            => x.HasValue && predicate(x.Value) ? x : null;
    }
}