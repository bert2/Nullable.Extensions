namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

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

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).Bind(GetFirstThreeLetters).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<string?>("12").Bind(GetFirstThreeLetters).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<string?>("1234").Bind(GetFirstThreeLetters).ShouldBe("123");

                private static string? GetFirstThreeLetters(string s) => s.Length >= 3 ? s[..3] : null;
            }

            public class Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<double?>(null).Bind(x => Divide(x, 3)).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<double?>(6).Bind(x => Divide(x, 0)).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<double?>(6).Bind(x => Divide(x, 3)).ShouldBe(2);

                private static double? Divide(double dividend, double divisor) => divisor == 0 ? (double?)null : dividend / divisor;
            }

            public class Class2Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).Bind(Parse).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<string?>("abc").Bind(Parse).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<string?>("123").Bind(Parse).ShouldBe(123);

                private static int? Parse(string s) => int.TryParse(s, out var i) ? i : (int?)null;
            }

            public class Struct2Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).Bind(PrintPositive).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<int?>(-13).Bind(PrintPositive).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<int?>(123).Bind(PrintPositive).ShouldBe("123");

                private static string? PrintPositive(int i) => i > 0 ? i.ToString() : null;
            }
        }
    }
}
