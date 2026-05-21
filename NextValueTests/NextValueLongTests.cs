namespace NextValueTests;

using NextValues;

[TestFixture]
public class NextValuelongTests
{

    [Test]
    public void NextValue_long_initial_value_without_seed_is_1()
    {
        var nextValue = new NextValue();
        Assert.That((long)nextValue, Is.EqualTo(1));
    }

    [Test]
    public void NextValue_long_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((long)nextValue, Is.EqualTo(100));
    }

    [Test]
    public void NextValue_long_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(i => (long)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void NextValue_long_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.Long(), Is.EqualTo(100));
    }

    [Test]
    public void NextValue_longArray_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.LongArray(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));

    }

    [Test]
    public void NextValue_longArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.LongArray(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void NextValue_longList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.LongList(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));

    }

    [Test]
    public void NextValue_longList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.LongList(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void NextValue_Reset_next_long_is_1()
    {
        var nextValue = new NextValue(100);
        var long1 = (long)nextValue;
        var long2 = (long)nextValue.Reset();

        Assert.That(long1, Is.EqualTo(100));
        Assert.That(long2, Is.EqualTo(1));
    }

    [Test]
    public void NextValue_Reset_with_value_next_long_is_value()
    {
        var nextValue = new NextValue(100);
        var long1 = (long)nextValue;
        var long2 = (long)nextValue.Reset(255);

        Assert.That(long1, Is.EqualTo(100));
        Assert.That(long2, Is.EqualTo(255));
    }
}
