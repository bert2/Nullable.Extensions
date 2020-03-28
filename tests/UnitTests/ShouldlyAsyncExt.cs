namespace UnitTests {
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Shouldly;

    public static class ShouldlyAsyncExt {
        public static async Task ShouldBe<T>(this Task<T> x, T expected) => (await x).ShouldBe(expected);

        public static async Task ShouldBeNull<T>(this Task<T> x) => (await x).ShouldBeNull();

        public static async Task ShouldBeTrue(this Task<bool> x) => (await x).ShouldBeTrue();

        public static async Task ShouldBeFalse(this Task<bool> x) => (await x).ShouldBeFalse();

        public static async Task ShouldBeEmpty<T>(this Task<IEnumerable<T>> x) => (await x).ShouldBeEmpty();

        public static async Task<T> ShouldHaveSingleItem<T>(this Task<IEnumerable<T>> x) => (await x).ShouldHaveSingleItem();
    }
}
