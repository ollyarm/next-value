namespace NextValueTests;

using NextValues;

public class NextValueDateOnlyTests
{
    [Test]
    public void NextValue_dateonly_initial_value_without_seed_is_first_value()
    {
        var nextValue = new NextValue();
        Assert.That((DateOnly)nextValue, Is.EqualTo(DateOnly.Parse("1900-01-06")));
    }

    [Test]
    public void NextValue_dateonlyinitial_value_with_seed_is_created_from_seed()
    {
        var nextValue = new NextValue(1000);
        Assert.That((DateOnly)nextValue, Is.EqualTo(DateOnly.Parse("1913-09-10")));
    }

    [Test]
    public void NextValue_dateonlymethod_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.DateOnly(), Is.EqualTo(DateOnly.Parse("1901-05-16")));
    }
}
