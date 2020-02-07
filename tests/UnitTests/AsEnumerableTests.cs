namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class AsEnumerableTests {
        public class Class {
            [Fact] public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((string?)null).AsEnumerable().ShouldBeEmpty();

            [Fact] public void ReturnsSingletonEnumerableWhenGivenValue()
                => "hi".AsEnumerable().ShouldHaveSingleItem().ShouldBe("hi");
        }

        public class Struct {
            [Fact]
            public void ReturnsEmptyEnumerableWhenGivenNull()
                => ((int?)null).AsEnumerable().ShouldBeEmpty();

            [Fact]
            public void ReturnsSingletonEnumerableWhenGivenValue()
                => ((int?)7).AsEnumerable().ShouldHaveSingleItem().ShouldBe(7);
        }
    }
}
