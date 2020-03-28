namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Nullable.Extensions.Async;
    using Shouldly;
    using System.Threading.Tasks;

    public static class FilterTests {
        public class Class {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((string?)null).Filter(x => x.Length > 3).ShouldBeNull();

            [Fact] public void ReturnsSameValueWhenItSatisfiesPredicate()
                => "1234".Filter(x => x.Length > 3).ShouldBe("1234");

            [Fact] public void TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                => "12".Filter(x => x.Length > 3).ShouldBeNull();
        }

        public class Struct {
            [Fact] public void ReturnsNullWhenGivenNull()
                => ((int?)null).Filter(x => x > 3).ShouldBeNull();

            [Fact] public void ReturnsSameValueWhenItSatisfiesPredicate()
                => ((int?)4).Filter(x => x > 3).ShouldBe(4);

            [Fact] public void TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                => ((int?)2).Filter(x => x > 3).ShouldBeNull();
        }

        public static class TaskOfNullable {
            public class Class {
                [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                    => await Task.FromResult<string?>("12").Filter(x => x.Length > 3).ShouldBeNull();
            }

            public class Struct {
                [Fact] public async Task TurnsValueIntoNullWhenItDoesNotSatisfyPredicate()
                    => await Task.FromResult<int?>(2).Filter(x => x > 3).ShouldBeNull();
            }
        }
    }
}
