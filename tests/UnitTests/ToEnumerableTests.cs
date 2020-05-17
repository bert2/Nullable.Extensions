namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class ToEnumerableTests {
        public class Class {
            [Fact] public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((string?)null).ToEnumerable().ShouldBeEmpty();

            [Fact] public void ReturnsSingletonEnumerableWhenGivenValue()
                => "hi".ToEnumerable().ShouldHaveSingleItem().ShouldBe("hi");
        }

        public class Struct {
            [Fact] public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((int?)null).ToEnumerable().ShouldBeEmpty();

            [Fact] public void ReturnsSingletonEnumerableWhenGivenValue()
                => ((int?)7).ToEnumerable().ShouldHaveSingleItem().ShouldBe(7);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task ReturnsEmptyEnumerableWhenGivenNull()
                    => await Task.FromResult<string?>(null).ToEnumerable().ShouldBeEmpty();

                [Fact] public async Task ReturnsSingletonEnumerableWhenGivenValue()
                    => await Task.FromResult<string?>("hi").ToEnumerable().ShouldHaveSingleItem().ShouldBe("hi");
            }

            public class Struct {
                [Fact] public async Task ReturnsEmptyEnumerableWhenGivenNull()
                    => await Task.FromResult<int?>(null).ToEnumerable().ShouldBeEmpty();

                [Fact] public async Task ReturnsSingletonEnumerableWhenGivenValue()
                    => await Task.FromResult<int?>(7).ToEnumerable().ShouldHaveSingleItem().ShouldBe(7);
            }
        }
    }
}
