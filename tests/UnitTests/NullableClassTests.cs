namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    using static Nullable.Extensions.NullableClass;

    public class NullableClassTests {
        [Fact] public void ParameterlessFactoryReturnsNull()
            => Nullable<string>().ShouldBeNull();

        // Can't really test whether the value actually is a `T?`.
        [Fact] public void FactoryReturnsParamterValue()
            => Nullable("hi").ShouldBe("hi");

        [Fact] public void ExtensionMethodFactoryReturnsParamterValue()
            => "hi".AsNullable().ShouldBe("hi");
    }
}
