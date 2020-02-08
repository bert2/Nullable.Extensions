namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class BindTests {
        public class Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).Bind(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => "12".Bind(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => "1234".Bind(GetFirstThreeLetters).ShouldBe("123");

            private static string? GetFirstThreeLetters(string s) => s.Length >= 3 ? s[..3] : null;
        }

        public class Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((double?)null).Bind(x => Divide(x, 3)).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => ((double?)6).Bind(x => Divide(x, 0)).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => ((double?)6).Bind(x => Divide(x, 3)).ShouldBe(2);

            private static double? Divide(double dividend, double divisor) => divisor == 0 ? (double?)null : dividend / divisor;
        }

        public class Class2Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).Bind(Parse).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => "abc".Bind(Parse).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => "123".Bind(Parse).ShouldBe(123);

            private static int? Parse(string s) => int.TryParse(s, out var i) ? i : (int?)null;
        }

        public class Struct2Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((int?)null).Bind(PrintPositive).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => ((int?)-13).Bind(PrintPositive).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => ((int?)123).Bind(PrintPositive).ShouldBe("123");

            private static string? PrintPositive(int i) => i > 0 ? i.ToString() : null;
        }
    }
}
