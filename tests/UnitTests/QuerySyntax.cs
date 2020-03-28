namespace UnitTests {
    using Xunit;
    using Nullable.Extensions;
    using Shouldly;

    using static Nullable.Extensions.NullableClass;
    using static Nullable.Extensions.NullableStruct;

    public static class QuerySyntax {
        public class Class {
            [Fact] public void ImplementsSelect() =>
                (from s in Nullable("hi")
                 select s)
                .ShouldBe("hi");

            [Fact] public void ImplementsSelectMany() =>
                (from s1 in Nullable("hello")
                 from s2 in Nullable("world")
                 select $"{s1} {s2}!")
                .ShouldBe("hello world!");
        }

        public class Struct {
            [Fact] public void ImplementsSelect() =>
                (from i in Nullable(3)
                 select i)
                .ShouldBe(3);

            [Fact] public void ImplementsSelectMany() =>
                (from i1 in Nullable(2)
                 from i2 in Nullable(3)
                 select i1 + i2)
                .ShouldBe(5);
        }

        public class Class2Struct {
            [Fact] public void ImplementsSelect() =>
                (from s in Nullable("3")
                 select int.Parse(s))
                .ShouldBe(3);
        }

        public class Struct2Class {
            [Fact] public void ImplementsSelect() =>
                (from i in Nullable(3)
                 select i.ToString())
                .ShouldBe("3");
        }

        public class ClassClass2Struct {
            [Fact] public void ImplementsSelectMany() =>
                (from s1 in Nullable("2")
                 from s2 in Nullable("3")
                 select int.Parse(s1) + int.Parse(s2))
                .ShouldBe(5);
        }

        public class ClassStruct2Class {
            [Fact] public void ImplementsSelectMany() =>
                (from s in Nullable("hello")
                 from i in Nullable(1)
                 select $"{s}!!{i}!")
                .ShouldBe("hello!!1!");
        }

        public class ClassStruct2Struct {
            [Fact] public void ImplementsSelectMany() =>
                (from s in Nullable("2")
                 from i in Nullable(3)
                 select int.Parse(s) + i)
                .ShouldBe(5);
        }

        public class StructClass2Class {
            [Fact] public void ImplementsSelectMany() =>
                (from i in Nullable(1)
                 from s in Nullable("hello")
                 select $"{s}!!{i}!")
                .ShouldBe("hello!!1!");
        }

        public class StructClass2Struct {
            [Fact] public void ImplementsSelectMany() =>
                (from i in Nullable(3)
                 from s in Nullable("2")
                 select int.Parse(s) + i)
                .ShouldBe(5);
        }

        public class StructStruct2Class {
            [Fact] public void ImplementsSelectMany() =>
                (from i1 in Nullable(2)
                 from i2 in Nullable(3)
                 select (i1 + i2).ToString())
                .ShouldBe("5");
        }
    }
}
