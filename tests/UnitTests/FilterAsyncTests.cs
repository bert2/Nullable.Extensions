namespace UnitTests {
    using Xunit;
    using Nullable.Extensions.Async;
    using System.Threading.Tasks;

    public static class FilterAsyncTests {
        public class Class {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((string?)null).FilterAsync(LongerThan3).ShouldBeNull();

            [Fact] public async Task ReturnsSameValueWhenItSatisfiesPredicate()
                => await "1234".FilterAsync(LongerThan3).ShouldBe("1234");

            [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                => await "12".FilterAsync(LongerThan3).ShouldBeNull();

            private static Task<bool> LongerThan3(string s) => Task.FromResult(s.Length > 3);
        }

        public class Struct {
            [Fact] public async Task ReturnsNullWhenGivenNull()
                => await ((int?)null).FilterAsync(GreaterThan3).ShouldBeNull();

            [Fact] public async Task ReturnsSameValueWhenItSatisfiesPredicate()
                => await ((int?)4).FilterAsync(GreaterThan3).ShouldBe(4);

            [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                => await ((int?)2).FilterAsync(GreaterThan3).ShouldBeNull();

            private static Task<bool> GreaterThan3(int i) => Task.FromResult(i > 3);
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                    => await Task.FromResult<string?>("12").FilterAsync(LongerThan3).ShouldBeNull();
            }

            public class Struct {
                [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                    => await Task.FromResult<int?>(2).FilterAsync(GreaterThan3).ShouldBeNull();
            }

            private static Task<bool> LongerThan3(string s) => Task.FromResult(s.Length > 3);

            private static Task<bool> GreaterThan3(int i) => Task.FromResult(i > 3);
        }
    }
}
