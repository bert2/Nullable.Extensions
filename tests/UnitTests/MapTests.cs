namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class MapTests {
        public class Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).Map(x => $"result: {x}").ShouldBeNull();

            [Fact] public void ReturnsMappingResult()
                => "test".Map(x => $"result: {x}").ShouldBe("result: test");
        }

        public class Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((int?)null).Map(x => x + 1).ShouldBeNull();

            [Fact] public void ReturnsMappingResult()
                => ((int?)1).Map(x => x + 1).ShouldBe(2);
        }

        public class Class2Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).Map(x => x.Length).ShouldBeNull();

            [Fact] public void ReturnsMappingResult()
                => "123".Map(x => x.Length).ShouldBe(3);
        }

        public class Struct2Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((int?)null).Map(x => x.ToString()).ShouldBeNull();

            [Fact] public void ReturnsMappingResult()
                => ((int?)3).Map(x => x.ToString()).ShouldBe("3");
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                => await Task.FromResult<string?>(null).Map((string x) => $"result: {x}").ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<string?>("test").Map((string x) => $"result: {x}").ShouldBe("result: test");
            }

            public class Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).Map(x => x + 1).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<int?>(1).Map(x => x + 1).ShouldBe(2);
            }

            public class Class2Struct {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<string?>(null).Map(x => x.Length).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<string?>("123").Map(x => x.Length).ShouldBe(3);
            }

            public class Struct2Class {
                [Fact] public async Task ReturnsNullWhenGivenNull()
                    => await Task.FromResult<int?>(null).Map((int x) => x.ToString()).ShouldBeNull();

                [Fact] public async Task ReturnsMappingResult()
                    => await Task.FromResult<int?>(3).Map((int x) => x.ToString()).ShouldBe("3");
            }
        }
    }
}
