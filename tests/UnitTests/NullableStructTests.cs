namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    using static Nullable.Extensions.NullableStruct;

    public class NullableStructTests {
        [Fact] public void ParameterlessFactoryReturnsNull()
            => Nullable<int>().ShouldBeNull();

        // Can't really test whether the value actually is a `T?`.
        [Fact] public void FactoryReturnsParamterValue()
            => Nullable(3).ShouldBe(3);

        [Fact] public void ExtensionMethodFactoryReturnsParamterValue()
            => 3.AsNullable().ShouldBe(3);
    }
}
