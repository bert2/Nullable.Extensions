namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    public static class SwitchTests {
        public class Class {
            [Fact] public void EvaluatesNullHandlerWhenGivenNull()
                => ((string?)null).Switch(notNull: _ => true, isNull: () => false).ShouldBeFalse();

            [Fact] public void EvaluatesValueHandlerWhenGivenValue()
                => "hi".Switch(notNull: _ => true, isNull: () => false).ShouldBeTrue();
        }

        public class Struct {
            [Fact] public void EvaluatesNullHandlerWhenGivenNull()
                => ((int?)null).Switch(notNull: _ => true, isNull: () => false).ShouldBeFalse();

            [Fact] public void EvaluatesValueHandlerWhenGivenValue()
                => ((int?)5).Switch(notNull: _ => true, isNull: () => false).ShouldBeTrue();
        }
    }
}
