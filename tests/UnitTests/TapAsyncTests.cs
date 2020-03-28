namespace UnitTests {
    using Nullable.Extensions.Async;
    using System.Threading.Tasks;
    using Shouldly;
    using Xunit;

    public static class TapAsyncTests {
        public class Class {
            [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                var hasValue = false;
                _ = await ((string?)null).TapAsync(_ => { hasValue = true; return Task.CompletedTask; });
                hasValue.ShouldBeFalse();
            }

            [Fact] public async Task ExecutesEffectWhenGivenValue() {
                var hasValue = false;
                _ = await "hi".TapAsync(_ => { hasValue = true; return Task.CompletedTask; });
                hasValue.ShouldBeTrue();
            }
        }

        public class Struct {
            [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                var hasValue = false;
                _ = await((int?)null).TapAsync(_ => { hasValue = true; return Task.CompletedTask; });
                hasValue.ShouldBeFalse();
            }

            [Fact] public async Task ExecutesEffectWhenGivenValue() {
                var hasValue = false;
                _ = await ((int?)3).TapAsync(_ => { hasValue = true; return Task.CompletedTask; });
                hasValue.ShouldBeTrue();
            }
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                    var hasValue = false;
                    _ = await Task.FromResult<string?>(null).TapAsync((string _) => { hasValue = true; return Task.CompletedTask; });
                    hasValue.ShouldBeFalse();
                }

                [Fact] public async Task ExecutesEffectWhenGivenValue() {
                    var hasValue = false;
                    _ = await Task.FromResult<string?>("hi").TapAsync((string _) => { hasValue = true; return Task.CompletedTask; });
                    hasValue.ShouldBeTrue();
                }
            }

            public class Struct {
                [Fact] public async Task DoesNotExecuteEffectWhenGivenNull() {
                    var hasValue = false;
                    _ = await Task.FromResult<int?>(null).TapAsync((int _) => { hasValue = true; return Task.CompletedTask; });
                    hasValue.ShouldBeFalse();
                }

                [Fact] public async Task ExecutesEffectWhenGivenValue() {
                    var hasValue = false;
                    _ = await Task.FromResult<int?>(3).TapAsync((int _) => { hasValue = true; return Task.CompletedTask; });
                    hasValue.ShouldBeTrue();
                }
            }
        }
    }
}
