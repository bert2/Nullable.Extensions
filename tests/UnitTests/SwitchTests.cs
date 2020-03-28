namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System;
    using System.Threading.Tasks;

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

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task EvaluatesValueHandlerWhenGivenValue()
                    => await Task.FromResult<string?>("hi").Switch(notNull: (string _) => true, isNull: () => false).ShouldBeTrue();

                [Fact] public async Task EvaluatesNullHandlerWhenGivenNull()
                    => await Task.FromResult<string?>(null).Switch(notNull: (string _) => true, isNull: () => false).ShouldBeFalse();

                [Fact] public async Task CanThrowExceptionWhenGivenNull() => await new Func<Task>(async () =>
                     await Task.FromResult<string?>(null).Switch(
                         notNull: (string _) => true,
                         isNull: () => throw new InvalidOperationException()))
                    .ShouldThrowAsync<InvalidOperationException>();
            }

            public class Struct {
                [Fact] public async Task EvaluatesValueHandlerWhenGivenValue()
                    => await Task.FromResult<int?>(5).Switch(notNull: (int _) => true, isNull: () => false).ShouldBeTrue();

                [Fact] public async Task EvaluatesNullHandlerWhenGivenNull()
                    => await Task.FromResult<int?>(null).Switch(notNull: (int _) => true, isNull: () => false).ShouldBeFalse();

                [Fact] public async Task CanThrowExceptionWhenGivenNull() => await new Func<Task>(async () =>
                     await Task.FromResult<int?>(null).Switch(
                         notNull: (int _) => true,
                         isNull: () => throw new InvalidOperationException()))
                    .ShouldThrowAsync<InvalidOperationException>();
            }
        }
    }
}
