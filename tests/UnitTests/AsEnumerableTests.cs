namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class AsEnumerableTests {
        public class Class {
            [Fact] public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((string?)null).AsEnumerable().ShouldBeEmpty();

            [Fact] public void ReturnsSingletonEnumerableWhenGivenValue()
                => "hi".AsEnumerable().ShouldHaveSingleItem().ShouldBe("hi");
        }

        public class Struct {
            [Fact] public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((int?)null).AsEnumerable().ShouldBeEmpty();

            [Fact] public void ReturnsSingletonEnumerableWhenGivenValue()
                => ((int?)7).AsEnumerable().ShouldHaveSingleItem().ShouldBe(7);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsEmptyEnumerableWhenGivenNull()
                    => await Task.FromResult<string?>(null).AsEnumerable().ShouldBeEmpty();

                [Fact] public async Task ReturnsSingletonEnumerableWhenGivenValue()
                    => await Task.FromResult<string?>("hi").AsEnumerable().ShouldHaveSingleItem().ShouldBe("hi");
            }

            public class Struct {
                [Fact] public async Task ReturnsEmptyEnumerableWhenGivenNull()
                    => await Task.FromResult<int?>(null).AsEnumerable().ShouldBeEmpty();

                [Fact] public async Task ReturnsSingletonEnumerableWhenGivenValue()
                    => await Task.FromResult<int?>(7).AsEnumerable().ShouldHaveSingleItem().ShouldBe(7);
            }
        }
    }
}
