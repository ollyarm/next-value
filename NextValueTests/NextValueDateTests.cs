namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueDateTests
{

    [Test]
    public void NextValue_datetime_initial_value_without_seed_is_first_value()
    {
        var nextValue = new NextValue();
        Assert.That((DateTime)nextValue, Is.EqualTo(DateTime.Parse("1900-01-01 18:12:24")));
    }

    [Test]
    public void NextValue_datetime_initial_value_without_seed_is_utc_now()
    {
        var nextValue = new NextValue();
        Assert.That(((DateTime)nextValue).Kind, Is.EqualTo(DateTimeKind.Utc));
    }

    [Test]
    public void NextValue_datetime_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((DateTime)nextValue, Is.EqualTo(DateTime.Parse("1900-01-27 08:40:00")));
    }

    [Test]
    public void NextValue_datetime_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(_ => (DateTime)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] {
            DateTime.Parse("1900-01-01 18:12:24"),
            DateTime.Parse("1900-01-02 00:24:48"),
            DateTime.Parse("1900-01-02 06:37:12"),
            DateTime.Parse("1900-01-02 12:49:36"),
            DateTime.Parse("1900-01-02 19:02:00"),
            DateTime.Parse("1900-01-03 01:14:24"),
        }));
    }

    [Test]
    public void NextValue_datetime_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.DateTime(), Is.EqualTo(DateTime.Parse("1900-01-27 08:40:00")));
    }

    [Test]
    public void NextValue_DateTimeArray_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeArray(10), Is.EqualTo(new[] {
            DateTime.Parse("1900-01-01 18:12:24"),
            DateTime.Parse("1900-01-02 00:24:48"),
            DateTime.Parse("1900-01-02 06:37:12"),
            DateTime.Parse("1900-01-02 12:49:36"),
            DateTime.Parse("1900-01-02 19:02:00"),
            DateTime.Parse("1900-01-03 01:14:24"),
            DateTime.Parse("1900-01-03 07:26:48"),
            DateTime.Parse("1900-01-03 13:39:12"),
            DateTime.Parse("1900-01-03 19:51:36"),
            DateTime.Parse("1900-01-04 02:04:00"),
        }));
    }

    [Test]
    public void NextValue_DateTimeArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeArray(), Is.EqualTo(new[]{
            DateTime.Parse("1900-01-01 18:12:24"),
            DateTime.Parse("1900-01-02 00:24:48"),
            DateTime.Parse("1900-01-02 06:37:12"),
        }));
    }

    [Test]
    public void NextValue_DateTimeList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeList(10), Is.EqualTo(new List<DateTime> {
            DateTime.Parse("1900-01-01 18:12:24"),
            DateTime.Parse("1900-01-02 00:24:48"),
            DateTime.Parse("1900-01-02 06:37:12"),
            DateTime.Parse("1900-01-02 12:49:36"),
            DateTime.Parse("1900-01-02 19:02:00"),
            DateTime.Parse("1900-01-03 01:14:24"),
            DateTime.Parse("1900-01-03 07:26:48"),
            DateTime.Parse("1900-01-03 13:39:12"),
            DateTime.Parse("1900-01-03 19:51:36"),
            DateTime.Parse("1900-01-04 02:04:00"),
        }));
    }

    [Test]
    public void NextValue_DateTimeList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DateTimeList(), Is.EqualTo(new List<DateTime> {
            DateTime.Parse("1900-01-01 18:12:24"),
            DateTime.Parse("1900-01-02 00:24:48"),
            DateTime.Parse("1900-01-02 06:37:12"),
        }));
    }
}
