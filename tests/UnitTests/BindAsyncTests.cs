namespace UnitTests {
    using Xunit;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class BindAsyncTests {
        public class Class {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((string?)null).BindAsync(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                => await "12".BindAsync(GetFirstThreeLetters).ShouldBeNull();

            [Fact] public async Task ReturnsBinderResult()
                => await "1234".BindAsync(GetFirstThreeLetters).ShouldBe("123");

            private static Task<string?> GetFirstThreeLetters(string s) => Task.FromResult(s.Length >= 3 ? s[..3] : null);
        }

        public class Struct {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((double?)null).BindAsync(x => Divide(x, 3)).ShouldBeNull();

            [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                => await ((double?)6).BindAsync(x => Divide(x, 0)).ShouldBeNull();

            [Fact] public async Task ReturnsBinderResult()
                => await ((double?)6).BindAsync(x => Divide(x, 3)).ShouldBe(2);

            private static Task<double?> Divide(double dividend, double divisor) => Task.FromResult(divisor == 0 ? (double?)null : dividend / divisor);
        }

        public class Class2Struct {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((string?)null).BindAsync(Parse).ShouldBeNull();

            [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                => await "abc".BindAsync(Parse).ShouldBeNull();

            [Fact] public async Task ReturnsBinderResult()
                => await "123".BindAsync(Parse).ShouldBe(123);

            private static Task<int?> Parse(string s) => Task.FromResult(int.TryParse(s, out var i) ? i : (int?)null);
        }

        public class Struct2Class {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((int?)null).BindAsync(PrintPositive).ShouldBeNull();

            [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                => await ((int?)-13).BindAsync(PrintPositive).ShouldBeNull();

            [Fact] public async Task ReturnsBinderResult()
                => await ((int?)123).BindAsync(PrintPositive).ShouldBe("123");

            private static Task<string?> PrintPositive(int i) => Task.FromResult(i > 0 ? i.ToString() : null);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).BindAsync(GetFirstThreeLetters).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<string?>("12").BindAsync(GetFirstThreeLetters).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<string?>("1234").BindAsync(GetFirstThreeLetters).ShouldBe("123");

                private static Task<string?> GetFirstThreeLetters(string s) => Task.FromResult(s.Length >= 3 ? s[..3] : null);
            }

            public class Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<double?>(null).BindAsync(x => Divide(x, 3)).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<double?>(6).BindAsync(x => Divide(x, 0)).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<double?>(6).BindAsync(x => Divide(x, 3)).ShouldBe(2);

                private static Task<double?> Divide(double dividend, double divisor) => Task.FromResult(divisor == 0 ? (double?)null : dividend / divisor);
            }

            public class Class2Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).BindAsync(Parse).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<string?>("abc").BindAsync(Parse).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<string?>("123").BindAsync(Parse).ShouldBe(123);

                private static Task<int?> Parse(string s) => Task.FromResult(int.TryParse(s, out var i) ? i : (int?)null);
            }

            public class Struct2Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).BindAsync(PrintPositive).ShouldBeNull();

                [Fact] public async Task ReturnsNullWhenBinderReturnsNull()
                    => await Task.FromResult<int?>(-13).BindAsync(PrintPositive).ShouldBeNull();

                [Fact] public async Task ReturnsBinderResult()
                    => await Task.FromResult<int?>(123).BindAsync(PrintPositive).ShouldBe("123");

                private static Task<string?> PrintPositive(int i) => Task.FromResult(i > 0 ? i.ToString() : null);
            }
        }
    }
}
