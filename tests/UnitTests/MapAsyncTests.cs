namespace UnitTests {
    using Xunit;
    using Nullable.Extensions.Async;
    using System.Threading.Tasks;

    public static class MapAsyncTests {
        public class Class {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((string?)null).MapAsync(Print).ShouldBeNull();

            [Fact] public async Task ReturnsMappingResult()
                => await "test".MapAsync(Print).ShouldBe("result: test");

            private static Task<string> Print(string s) => Task.FromResult($"result: {s}");
        }

        public class Struct {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((int?)null).MapAsync(Inc).ShouldBeNull();

            [Fact] public async Task ReturnsMappingResult()
                => await ((int?)1).MapAsync(Inc).ShouldBe(2);

            private static Task<int> Inc(int n) => Task.FromResult(n + 1);
        }

        public class Class2Struct {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((string?)null).MapAsync(Len).ShouldBeNull();

            [Fact] public async Task ReturnsMappingResult()
                => await "123".MapAsync(Len).ShouldBe(3);

            private static Task<int> Len(string s) => Task.FromResult(s.Length);
        }

        public class Struct2Class {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((int?)null).MapAsync(Print).ShouldBeNull();

            [Fact] public async Task ReturnsMappingResult()
                => await ((int?)3).MapAsync(Print).ShouldBe("3");

            private static Task<string> Print(int i) => Task.FromResult(i.ToString());
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).MapAsync(Print).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<string?>("test").MapAsync(Print).ShouldBe("result: test");

                private static Task<string> Print(string s) => Task.FromResult($"result: {s}");
            }

            public class Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).MapAsync(Inc).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<int?>(1).MapAsync(Inc).ShouldBe(2);

                private static Task<int> Inc(int n) => Task.FromResult(n + 1);
            }

            public class Class2Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).MapAsync(Len).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<string?>("123").MapAsync(Len).ShouldBe(3);

                private static Task<int> Len(string s) => Task.FromResult(s.Length);
            }

            public class Struct2Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).MapAsync(Print).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<int?>(3).MapAsync(Print).ShouldBe("3");

                private static Task<string> Print(int i) => Task.FromResult(i.ToString());
            }
        }
    }
}
