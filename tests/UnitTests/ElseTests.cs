namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class ElseTests {
        public class Class {
            [Fact] public void JustForwardsNonNullValues()
                => "123".Else(() => "456").ShouldBe("123");

            [Fact] public void EvaluatesAlternativeForNullValues()
                => ((string?)null).Else(() => "456").ShouldBe("456");
        }

        public class Struct {
            [Fact] public void JustForwardsNonNullValues()
                => ((int?)13).Else(() => 42).ShouldBe(13);

            [Fact]
            public void EvaluatesAlternativeForNullValues()
                => ((int?)null).Else(() => 42).ShouldBe(42);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task EvaluatesAlternativeForNullValues()
                    => await Task.FromResult<string?>(null).Else(() => "456").ShouldBe("456");
            }

            public class Struct {
                [Fact] public async Task EvaluatesAlternativeForNullValues()
                    => await Task.FromResult<int?>(null).Else(() => 42).ShouldBe(42);
            }
        }
    }
}
