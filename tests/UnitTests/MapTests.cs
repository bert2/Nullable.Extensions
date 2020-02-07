namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

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
    }
}
