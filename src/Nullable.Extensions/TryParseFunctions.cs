namespace Nullable.Extensions {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    [ExcludeFromCodeCoverage]
    public static class TryParseFunctions {
        public static bool? TryParseBool(string value) => bool.TryParse(value, out var result) ? (bool?)result : null;

        public static byte? TryParseByte(string value) => byte.TryParse(value, out var result) ? (byte?)result : null;
        public static byte? TryParseByte(string value, NumberStyles style, IFormatProvider provider) => byte.TryParse(value, style, provider, out var result) ? (byte?)result : null;

        public static sbyte? TryParseSByte(string value) => sbyte.TryParse(value, out var result) ? (sbyte?)result : null;
        public static sbyte? TryParseSByte(string value, NumberStyles style, IFormatProvider provider) => sbyte.TryParse(value, style, provider, out var result) ? (sbyte?)result : null;

        public static char? TryParseChar(string value) => char.TryParse(value, out var result) ? (char?)result : null;

        public static decimal? TryParseDecimal(string value) => decimal.TryParse(value, out var result) ? (decimal?)result : null;
        public static decimal? TryParseDecimal(string value, NumberStyles style, IFormatProvider provider) => decimal.TryParse(value, style, provider, out var result) ? (decimal?)result : null;

        public static double? TryParseDouble(string value) => double.TryParse(value, out var result) ? (double?)result : null;
        public static double? TryParseDouble(string value, NumberStyles style, IFormatProvider provider) => double.TryParse(value, style, provider, out var result) ? (double?)result : null;

        public static float? TryParseFloat(string value) => float.TryParse(value, out var result) ? (float?)result : null;
        public static float? TryParseFloat(string value, NumberStyles style, IFormatProvider provider) => float.TryParse(value, style, provider, out var result) ? (float?)result : null;

        public static int? TryParseInt(string value) => int.TryParse(value, out var result) ? (int?)result : null;
        public static int? TryParseInt(string value, NumberStyles style, IFormatProvider provider) => int.TryParse(value, style, provider, out var result) ? (int?)result : null;

        public static uint? TryParseUInt(string value) => uint.TryParse(value, out var result) ? (uint?)result : null;
        public static uint? TryParseUInt(string value, NumberStyles style, IFormatProvider provider) => uint.TryParse(value, style, provider, out var result) ? (uint?)result : null;

        public static long? TryParseLong(string value) => long.TryParse(value, out var result) ? (long?)result : null;
        public static long? TryParseLong(string value, NumberStyles style, IFormatProvider provider) => long.TryParse(value, style, provider, out var result) ? (long?)result : null;

        public static ulong? TryParseULong(string value) => ulong.TryParse(value, out var result) ? (ulong?)result : null;
        public static ulong? TryParseULong(string value, NumberStyles style, IFormatProvider provider) => ulong.TryParse(value, style, provider, out var result) ? (ulong?)result : null;

        public static short? TryParseShort(string value) => short.TryParse(value, out var result) ? (short?)result : null;
        public static short? TryParseShort(string value, NumberStyles style, IFormatProvider provider) => short.TryParse(value, style, provider, out var result) ? (short?)result : null;

        public static ushort? TryParseUShort(string value) => ushort.TryParse(value, out var result) ? (ushort?)result : null;
        public static ushort? TryParseUShort(string value, NumberStyles style, IFormatProvider provider) => ushort.TryParse(value, style, provider, out var result) ? (ushort?)result : null;

        public static DateTime? TryParseDateTime(string value) => DateTime.TryParse(value, out var result) ? (DateTime?)result : null;
        public static DateTime? TryParseDateTime(string value, IFormatProvider provider, DateTimeStyles styles) => DateTime.TryParse(value, provider, styles, out var result) ? (DateTime?)result : null;
        public static DateTime? TryParseDateTimeExact(string value, string format, IFormatProvider provider, DateTimeStyles style) => DateTime.TryParseExact(value, format, provider, style, out var result) ? (DateTime?)result : null;
        public static DateTime? TryParseDateTimeExact(string value, string[] formats, IFormatProvider provider, DateTimeStyles style) => DateTime.TryParseExact(value, formats, provider, style, out var result) ? (DateTime?)result : null;

        public static DateTimeOffset? TryParseDateTimeOffset(string value) => DateTimeOffset.TryParse(value, out var result) ? (DateTimeOffset?)result : null;
        public static DateTimeOffset? TryParseDateTimeOffset(string value, IFormatProvider provider, DateTimeStyles styles) => DateTimeOffset.TryParse(value, provider, styles, out var result) ? (DateTimeOffset?)result : null;
        public static DateTimeOffset? TryParseDateTimeOffsetExact(string value, string format, IFormatProvider provider, DateTimeStyles style) => DateTimeOffset.TryParseExact(value, format, provider, style, out var result) ? (DateTimeOffset?)result : null;
        public static DateTimeOffset? TryParseDateTimeOffsetExact(string value, string[] formats, IFormatProvider provider, DateTimeStyles style) => DateTimeOffset.TryParseExact(value, formats, provider, style, out var result) ? (DateTimeOffset?)result : null;

        public static TimeSpan? TryParseTimeSpan(string value) => TimeSpan.TryParse(value, out var result) ? (TimeSpan?)result : null;
        public static TimeSpan? TryParseTimeSpan(string value, IFormatProvider provider) => TimeSpan.TryParse(value, provider, out var result) ? (TimeSpan?)result : null;
        public static TimeSpan? TryParseTimeSpanExact(string value, string format, IFormatProvider provider) => TimeSpan.TryParseExact(value, format, provider, out var result) ? (TimeSpan?)result : null;
        public static TimeSpan? TryParseTimeSpanExact(string value, string format, IFormatProvider provider, TimeSpanStyles style) => TimeSpan.TryParseExact(value, format, provider, style, out var result) ? (TimeSpan?)result : null;
        public static TimeSpan? TryParseTimeSpanExact(string value, string[] formats, IFormatProvider provider) => TimeSpan.TryParseExact(value, formats, provider, out var result) ? (TimeSpan?)result : null;
        public static TimeSpan? TryParseTimeSpanExact(string value, string[] formats, IFormatProvider provider, TimeSpanStyles style) => TimeSpan.TryParseExact(value, formats, provider, style, out var result) ? (TimeSpan?)result : null;

        public static Guid? TryParseGuid(string value) => Guid.TryParse(value, out var result) ? (Guid?)result : null;
        public static Guid? TryParseGuidExact(string value, string format) => Guid.TryParseExact(value, format, out var result) ? (Guid?)result : null;
    }
}
