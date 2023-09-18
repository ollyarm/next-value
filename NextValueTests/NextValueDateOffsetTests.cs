namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueDateOffsetTests
{

    [Test]
    public void NextValue_datetimeoffset_initial_value_without_seed_is_first_value()
    {
        var nextValue = new NextValue();
        Assert.That((DateTimeOffset)nextValue, Is.EqualTo(DateTimeOffset.Parse("1900-01-01 08:12:24-10:00")));
    }

    [Test]
    public void NextValue_datetimeoffset_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((DateTimeOffset)nextValue, Is.EqualTo(DateTimeOffset.Parse("1900-01-27 01:40:00-07:00")));
    }

    [Test]
    public void NextValue_datetimeoffset_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(_ => (DateTimeOffset)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] {
            DateTimeOffset.Parse("1900-01-01 08:12:24-10:00"),
            DateTimeOffset.Parse("1900-01-01 22:37:12-08:00"),
            DateTimeOffset.Parse("1900-01-02 13:02:00-06:00"),
            DateTimeOffset.Parse("1900-01-03 03:26:48-04:00"),
            DateTimeOffset.Parse("1900-01-03 17:51:36-02:00"),
            DateTimeOffset.Parse("1900-01-04 08:16:24+00:00"),
        }));
    }

    [Test]
    public void NextValue_datetimeoffset_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.DateTimeOffset(), Is.EqualTo(DateTimeOffset.Parse("1900-01-27 01:40:00-07:00")));
    }

    [Test]
    public void NextValue_DateTimeArray_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeOffsetArray(10), Is.EqualTo(new[] {
            DateTimeOffset.Parse("1900-01-01 08:12:24-10:00"),
            DateTimeOffset.Parse("1900-01-01 22:37:12-08:00"),
            DateTimeOffset.Parse("1900-01-02 13:02:00-06:00"),
            DateTimeOffset.Parse("1900-01-03 03:26:48-04:00"),
            DateTimeOffset.Parse("1900-01-03 17:51:36-02:00"),
            DateTimeOffset.Parse("1900-01-04 08:16:24+00:00"),
            DateTimeOffset.Parse("1900-01-04 22:41:12+02:00"),
            DateTimeOffset.Parse("1900-01-05 13:06:00+04:00"),
            DateTimeOffset.Parse("1900-01-06 03:30:48+06:00"),
            DateTimeOffset.Parse("1900-01-06 17:55:36+08:00"),
        }));
    }

    [Test]
    public void NextValue_DateTimeArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeOffsetArray(), Is.EqualTo(new[]{
            DateTimeOffset.Parse("1900-01-01 08:12:24-10:00"),
            DateTimeOffset.Parse("1900-01-01 22:37:12-08:00"),
            DateTimeOffset.Parse("1900-01-02 13:02:00-06:00"),
        }));
    }

    [Test]
    public void NextValue_DateTimeList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeOffsetList(10), Is.EqualTo(new List<DateTimeOffset> {
            DateTimeOffset.Parse("1900-01-01 08:12:24-10:00"),
            DateTimeOffset.Parse("1900-01-01 22:37:12-08:00"),
            DateTimeOffset.Parse("1900-01-02 13:02:00-06:00"),
            DateTimeOffset.Parse("1900-01-03 03:26:48-04:00"),
            DateTimeOffset.Parse("1900-01-03 17:51:36-02:00"),
            DateTimeOffset.Parse("1900-01-04 08:16:24+00:00"),
            DateTimeOffset.Parse("1900-01-04 22:41:12+02:00"),
            DateTimeOffset.Parse("1900-01-05 13:06:00+04:00"),
            DateTimeOffset.Parse("1900-01-06 03:30:48+06:00"),
            DateTimeOffset.Parse("1900-01-06 17:55:36+08:00"),
        }));
    }

    [Test]
    public void NextValue_DateTimeList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeOffsetList(), Is.EqualTo(new List<DateTimeOffset> {
            DateTimeOffset.Parse("1900-01-01 08:12:24-10:00"),
            DateTimeOffset.Parse("1900-01-01 22:37:12-08:00"),
            DateTimeOffset.Parse("1900-01-02 13:02:00-06:00"),
        }));
    }
}
