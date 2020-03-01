namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class SelectMany1Tests {
        public class Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).SelectMany(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => "12".SelectMany(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => "1234".SelectMany(GetFirstThreeLetters).ShouldBe("123");

            private static string? GetFirstThreeLetters(string s) => s.Length >= 3 ? s[..3] : null;
        }

        public class Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((double?)null).SelectMany(x => Divide(x, 3)).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => ((double?)6).SelectMany(x => Divide(x, 0)).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => ((double?)6).SelectMany(x => Divide(x, 3)).ShouldBe(2);

            private static double? Divide(double dividend, double divisor) => divisor == 0 ? (double?)null : dividend / divisor;
        }

        public class Class2Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).SelectMany(Parse).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => "abc".SelectMany(Parse).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => "123".SelectMany(Parse).ShouldBe(123);

            private static int? Parse(string s) => int.TryParse(s, out var i) ? i : (int?)null;
        }

        public class Struct2Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((int?)null).SelectMany(PrintPositive).ShouldBeNull();

            [Fact] public void ReturnsNullWhenBinderReturnsNull()
                => ((int?)-13).SelectMany(PrintPositive).ShouldBeNull();

            [Fact] public void ReturnsBinderResult()
                => ((int?)123).SelectMany(PrintPositive).ShouldBe("123");

            private static string? PrintPositive(int i) => i > 0 ? i.ToString() : null;
        }
    }
}
