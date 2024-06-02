namespace NextValueTests;

using NextValues;

public class NextValueTimeOnlyTests
{
    [Test]
    public void NextValue_timeonly_initial_value_without_seed_is_first_value()
    {
        var nextValue = new NextValue();
        Assert.That((TimeOnly)nextValue, Is.EqualTo(TimeOnly.Parse("12:02:55")));
    }

    [Test]
    public void NextValue_timeonlyinitial_value_with_seed_is_created_from_seed()
    {
        var nextValue = new NextValue(1000);
        Assert.That((TimeOnly)nextValue, Is.EqualTo(TimeOnly.Parse("12:36:40")));
    }

    [Test]
    public void NextValue_timeonlymethod_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.TimeOnly(), Is.EqualTo(TimeOnly.Parse("16:51:40")));
    }
}