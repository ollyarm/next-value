namespace NextValueTests;

using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NextValue;

public class NextValueObjectTests
{
    [Test]
    public void NextValue_New_returns_constructed_object()
    {
        var nextValue = new NextValue();
        var result = nextValue.New<TestObject>();

        Assert.Multiple(() =>
        {
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ExampleInt, Is.EqualTo(1));
            Assert.That(result.ExampleNullableInt, Is.EqualTo(2));
            Assert.That(result.ExampleString, Is.EqualTo("ExampleString 3"));
            Assert.That(result.ExampleDecimal, Is.EqualTo(4.05m));
            Assert.That(result.ExampleNullableDecimal, Is.EqualTo(6.07m));
            Assert.That(result.ExampleDouble, Is.EqualTo(8.09d));
            Assert.That(result.ExampleNullableDouble, Is.EqualTo(10.11d));
            Assert.That(result.ExampleFloat, Is.EqualTo(12.13f));
            Assert.That(result.ExampleNullableFloat, Is.EqualTo(14.15f));
            Assert.That(result.ExampleBool, Is.EqualTo(true));
            Assert.That(result.ExampleNullableBool, Is.EqualTo(true));
            Assert.That(result.ExampleDateTime, Is.EqualTo(DateTime.Parse("1900-01-06 03:43:12")));
            Assert.That(result.ExampleNullableDateTime, Is.EqualTo(DateTime.Parse("1900-01-06 09:55:36")));
            Assert.That(result.ExampleDateTimeOffset, Is.EqualTo(DateTimeOffset.Parse("1900-01-07 01:08:00+09:00")));
            Assert.That(result.ExampleNullableDateTimeOffset, Is.EqualTo(DateTimeOffset.Parse("1900-01-07 15:32:48+11:00")));
            Assert.That(result.ExampleGuid, Is.EqualTo(Guid.Parse("00000000-0000-0000-0000-000000000024")));
            Assert.That(result.ExampleNullableGuid, Is.EqualTo(Guid.Parse("00000000-0000-0000-0000-000000000025")));
            Assert.That(result.ExampleEnum, Is.EqualTo(TestObject.TestEnum.Two));
            Assert.That(result.ExampleNullableEnum, Is.EqualTo(TestObject.TestEnum.Three));
            Assert.That(result.ExampleObject, Is.Null);
        });
    }

    [Test]
    public void NextValue_New_with_constucted_returns__original_object()
    {
        var nextValue = new NextValue();

        var original = new TestObject();

        var result = nextValue.New(() => original);
        
        Assert.That(result, Is.EqualTo(original));
    }

    private class TestObject
    {
        public int ExampleInt { get; set; }
        public int? ExampleNullableInt { get; set; }
        public string ExampleString { get; set; } = "";
        public decimal ExampleDecimal { get; set; }
        public decimal? ExampleNullableDecimal { get; set; }
        public double ExampleDouble { get; set; }
        public double? ExampleNullableDouble { get; set; }
        public float ExampleFloat { get; set; }
        public float? ExampleNullableFloat { get; set; }
        public bool ExampleBool { get; set; }
        public bool? ExampleNullableBool { get; set; }
        public DateTime ExampleDateTime { get; set; }
        public DateTime? ExampleNullableDateTime { get; set; }
        public DateTimeOffset ExampleDateTimeOffset { get; set; }
        public DateTimeOffset? ExampleNullableDateTimeOffset { get; set; }
        public Guid ExampleGuid { get; set; }
        public Guid? ExampleNullableGuid { get; set; }
        public TestEnum ExampleEnum { get; set; }
        public TestEnum? ExampleNullableEnum { get; set; }

        public TestObject? ExampleObject { get; set; }

        public enum TestEnum
        {
            Unkown = 0,
            One = 1,
            Two = 2,
            Three = 3,
            Ten = 10,
        }
    }
}
