namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;
    using System.Linq;
    using System;

    public static class ToNullableTests {
        public class Class {
            [Fact] public void ReturnsNullWhenGivenEmptyEnumerable()
                => Enumerable.Empty<string>().ToNullable().ShouldBeNull();

            [Fact] public void ReturnsValueWhenGivenSingletonEnumerable()
                => Enumerable.Repeat("hi", 1).ToNullable().ShouldBe("hi");

            [Fact]
            public void ThrowsWhenGivenEnumerableWithMoreThanOneItem() => new Action(() =>
                Enumerable.Repeat("hi", 2).ToNullable())
                .ShouldThrow<InvalidOperationException>();
        }

        public class Struct {
            [Fact] public void ReturnsNullWhenGivenEmptyEnumerable()
                => Enumerable.Empty<int>().ToNullable().ShouldBeNull();

            [Fact] public void ReturnsValueWhenGivenSingletonEnumerable()
                => Enumerable.Repeat(7, 1).ToNullable().ShouldBe(7);

            [Fact] public void ThrowsWhenGivenEnumerableWithMoreThanOneItem() => new Action(() =>
                Enumerable.Repeat(7, 2).ToNullable())
                .ShouldThrow<InvalidOperationException>();
        }
    }
}
