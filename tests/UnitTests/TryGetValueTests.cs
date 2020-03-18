namespace UnitTests {
    using System.Collections.Generic;
    using Nullable.Extensions;
    using Shouldly;
    using Xunit;

    public static class TryGetValueTests {
        public class Class {
            [Fact] public void ReturnsNullWhenKeyIsMissing() =>
                new Dictionary<int, string>()
                .TryGetValue(13)
                .ShouldBe(null);

            [Fact] public void ReturnsValueWhenKeyIsPresent() =>
                new Dictionary<int, string> { [13] = "lucky" }
                .TryGetValue(13)
                .ShouldBe("lucky");
        }
    }
}
