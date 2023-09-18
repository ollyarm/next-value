namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueIntTests
{

    [Test]
    public void NextValue_int_initial_value_without_seed_is_1()
    {
        var nextValue = new NextValue();
        Assert.That((int)nextValue, Is.EqualTo(1));
    }

    [Test]
    public void NextValue_int_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((int)nextValue, Is.EqualTo(100));
    }

    [Test]
    public void NextValue_int_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(i => (int)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6 }));
    }

    [Test]
    public void NextValue_int_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.Int(), Is.EqualTo(100));
    }
}
