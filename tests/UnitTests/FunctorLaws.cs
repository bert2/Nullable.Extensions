namespace UnitTests {
    using System.Text.RegularExpressions;
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class FunctorLaws {
        public class Class {
            [Theory, InlineData("hi"), InlineData(null)]
            public void PreservesIdentity(string? x)
                => x.Map(Id).ShouldBe(Id(x));

            [Theory, InlineData("HI!"), InlineData(null)]
            public void PreservesComposition(string? x) =>
                x.Map(x => AppendLen(RemoveSpecial(x)))
                .ShouldBe(x.Map(RemoveSpecial).Map(AppendLen));

            private static T Id<T>(T x) => x;

            private static string AppendLen(string s) => $"{s}{s.Length}";

            private static string RemoveSpecial(string s) => Regex.Replace(s, @"\W", "");
        }

        public class Struct {
            [Theory, InlineData(3), InlineData(null)]
            public void PreservesIdentity(int? x)
                => x.Map(Id).ShouldBe(Id(x));

            [Theory, InlineData(3), InlineData(null)]
            public void PreservesComposition(int? x) =>
                x.Map(x => Square(Inc(x)))
                .ShouldBe(x.Map(Inc).Map(Square));

            private static T Id<T>(T x) => x;

            private static int Inc(int x) => x + 1;

            private static int Square(int x) => x * x;
        }

        public class Class2Struct {
            [Theory, InlineData("hi"), InlineData(null)]
            public void PreservesComposition(string? x) =>
                x.Map(x => Print(Length(x)))
                .ShouldBe(x.Map(Length).Map(Print));

            private static int Length(string s) => s.Length;

            private static string Print(int i) => i.ToString();
        }

        public class Struct2Class {
            [Theory, InlineData(13), InlineData(null)]
            public void PreservesComposition(int? x) =>
                x.Map(x => Length(Print(x)))
                .ShouldBe(x.Map(Print).Map(Length));

            private static string Print(int i) => i.ToString();

            private static int Length(string s) => s.Length;
        }
    }
}
