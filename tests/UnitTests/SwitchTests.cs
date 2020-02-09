namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;
    using System;

    public static class SwitchTests {
        public class Class {
            [Fact] public void EvaluatesValueHandlerWhenGivenValue()
                => "hi".Switch(notNull: _ => true, isNull: () => false).ShouldBeTrue();

            [Fact] public void EvaluatesNullHandlerWhenGivenNull()
                => ((string?)null).Switch(notNull: _ => true, isNull: () => false).ShouldBeFalse();

            [Fact] public void CanThrowExceptionWhenGivenNull() => new Action(() =>
                ((string?)null).Switch(
                    notNull: _ => true,
                    isNull: () => throw new InvalidOperationException()))
                .ShouldThrow<InvalidOperationException>();
        }

        public class Struct {
            [Fact] public void EvaluatesValueHandlerWhenGivenValue()
                => ((int?)5).Switch(notNull: _ => true, isNull: () => false).ShouldBeTrue();

            [Fact] public void EvaluatesNullHandlerWhenGivenNull()
                => ((int?)null).Switch(notNull: _ => true, isNull: () => false).ShouldBeFalse();

            [Fact] public void CanThrowExceptionWhenGivenNull() => new Action(() =>
                ((int?)null).Switch(
                    notNull: _ => true,
                    isNull: () => throw new InvalidOperationException()))
                .ShouldThrow<InvalidOperationException>();
        }
    }
}
