namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    using static Nullable.Extensions.NullableClass;
    using static Nullable.Extensions.NullableStruct;
    using System;

    public static class MonadLaws {
        public class Class {
            [Theory, InlineData("1234"), InlineData("12")]
            public void LeftIdentity(string x)
                => Nullable(x).Bind(GetFirstThreeLetters).ShouldBe(GetFirstThreeLetters(x));

            [Theory, InlineData("hi"), InlineData(null)]
            public void RightIdentity(string? m)
                => m.Bind(Nullable).ShouldBe(m);

            [Theory, InlineData("1234"), InlineData(null)]
            public void Associativity(string? m) =>
                m.Bind(GetFirstThreeLetters).Bind(GetLastThreeLetters)
                .ShouldBe(m.Bind(x => GetFirstThreeLetters(x).Bind(GetLastThreeLetters)));

            private static string? GetFirstThreeLetters(string s) => s.Length >= 3 ? s[..3] : null;

            private static string? GetLastThreeLetters(string s) => s.Length >= 3 ? s[^3..] : null;
        }

        public class Struct {
            [Theory, InlineData(3), InlineData(0)]
            public void LeftIdentity(double divisor)
                => Nullable(6.0).Bind(x => Divide(x, divisor)).ShouldBe(Divide(6, divisor));

            [Theory, InlineData(1), InlineData(null)]
            public void RightIdentity(int? m)
                => m.Bind(Nullable).ShouldBe(m);

            [Theory, InlineData(6), InlineData(null)]
            public void Associativity(double? m) =>
                m.Bind(x => Divide(x, 3)).Bind(Sqrt)
                .ShouldBe(m.Bind(x => Divide(x, 3).Bind(Sqrt)));

            private static double? Divide(double dividend, double divisor) => divisor == 0 ? (double?)null : dividend / divisor;

            private static double? Sqrt(double x) => x < 0 ? (double?)null : Math.Sqrt(x);
        }

        public class Class2Struct {
            [Theory, InlineData("123"), InlineData("abc")]
            public void LeftIdentity(string x)
                => Nullable(x).Bind(Parse).ShouldBe(Parse(x));

            [Theory, InlineData("1234"), InlineData(null)]
            public void Associativity(string? m) =>
                m.Bind(Parse).Bind(PrintPositive)
                .ShouldBe(m.Bind(x => Parse(x).Bind(PrintPositive)));

            private static int? Parse(string s) => int.TryParse(s, out var i) ? i : (int?)null;

            private static string? PrintPositive(int i) => i > 0 ? i.ToString() : null;
        }

        public class Struct2Class {
            [Theory, InlineData(123), InlineData(-13)]
            public void LeftIdentity(int x)
                => Nullable(x).Bind(PrintPositive).ShouldBe(PrintPositive(x));

            [Theory, InlineData(3), InlineData(null)]
            public void Associativity(int? m) =>
                m.Bind(PrintPositive).Bind(Parse)
                .ShouldBe(m.Bind(x => PrintPositive(x).Bind(Parse)));

            private static string? PrintPositive(int i) => i > 0 ? i.ToString() : null;

            private static int? Parse(string s) => int.TryParse(s, out var i) ? i : (int?)null;
        }
    }
}
