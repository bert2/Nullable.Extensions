namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

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

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                    var hasValue = false;
                    _ = await Task.FromResult<string?>(null).Tap((string _) => hasValue = true);
                    hasValue.ShouldBeFalse();
                }

                [Fact] public async Task ExecutesEffectWhenGivenValue() {
                    var hasValue = false;
                    _ = await Task.FromResult<string?>("hi").Tap((string _) => hasValue = true);
                    hasValue.ShouldBeTrue();
                }
            }

            public class Struct {
                [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                    var hasValue = false;
                    _ = await Task.FromResult<int?>(null).Tap((int _) => hasValue = true);
                    hasValue.ShouldBeFalse();
                }

                [Fact] public async Task ExecutesEffectWhenGivenValue() {
                    var hasValue = false;
                    _ = await Task.FromResult<int?>(3).Tap((int _) => hasValue = true);
                    hasValue.ShouldBeTrue();
                }
            }
        }
    }
}
