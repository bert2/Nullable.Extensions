namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class TapTests {
        public class Class {
            [Fact] public void DoesNotExecuteEffectWhenGivenNull() {
                var hasValue = false;
                _ = ((string?)null).Tap(_ => hasValue = true);
                hasValue.ShouldBeFalse();
            }

            [Fact] public void ExecutesEffectWhenGivenValue() {
                var hasValue = false;
                _ = "hi".Tap(_ => hasValue = true);
                hasValue.ShouldBeTrue();
            }
        }

        public class Struct {
            [Fact] public void DoesNotExecuteEffectWhenGivenNull() {
                var hasValue = false;
                _ = ((int?)null).Tap(_ => hasValue = true);
                hasValue.ShouldBeFalse();
            }

            [Fact] public void ExecutesEffectWhenGivenValue() {
                var hasValue = false;
                _ = ((int?)3).Tap(_ => hasValue = true);
                hasValue.ShouldBeTrue();
            }
        }
    }
}
