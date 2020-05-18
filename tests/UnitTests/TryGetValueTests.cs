namespace UnitTests {
    using System.Collections.Generic;
    using Nullable.Extensions.Util;
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

        public class Struct {
            [Fact] public void ReturnsNullWhenKeyIsMissing() =>
                new Dictionary<int, int>()
                .TryGetValue(13)
                .ShouldBe(null);

            [Fact] public void ReturnsValueWhenKeyIsPresent() =>
                new Dictionary<int, int> { [13] = 7 }
                .TryGetValue(13)
                .ShouldBe(7);
        }
    }
}
