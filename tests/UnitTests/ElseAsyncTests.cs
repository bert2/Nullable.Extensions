namespace UnitTests {
    using Xunit;
    using Nullable.Extensions.Async;
    using System.Threading.Tasks;

    public static class ElseAsyncTests {
        public class Class {
            [Fact] public async Task JustForwardsNonNullValues()
                => await "123".ElseAsync(Alternative).ShouldBe("123");

            [Fact] public async Task EvaluatesAlternativeForNullValues()
                => await ((string?)null).ElseAsync(Alternative).ShouldBe("456");

            private static Task<string?> Alternative() => Task.FromResult<string?>("456");
        }

        public class Struct {
            [Fact] public async Task JustForwardsNonNullValues()
                => await ((int?)13).ElseAsync(Alternative).ShouldBe(13);

            [Fact] public async Task EvaluatesAlternativeForNullValues()
                => await ((int?)null).ElseAsync(Alternative).ShouldBe(42);

            private static Task<int?> Alternative() => Task.FromResult<int?>(42);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task EvaluatesAlternativeForNullValues()
                    => await Task.FromResult<string?>(null).ElseAsync(AlternativeString).ShouldBe("456");
            }

            public class Struct {
                [Fact] public async Task EvaluatesAlternativeForNullValues()
                    => await Task.FromResult<int?>(null).ElseAsync(AlternativeNumber).ShouldBe(42);
            }

            private static Task<string?> AlternativeString() => Task.FromResult<string?>("456");

            private static Task<int?> AlternativeNumber() => Task.FromResult<int?>(42);
        }
    }
}
