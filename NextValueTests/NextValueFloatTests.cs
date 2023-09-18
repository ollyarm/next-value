namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueFloatTests
{

    [Test]
    public void NextValue_float_initial_value_without_seed_is_initial()
    {
        var nextValue = new NextValue();
        Assert.That((float)nextValue, Is.EqualTo(1.02f));
    }

    [Test]
    public void NextValue_float_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((float)nextValue, Is.EqualTo(100.01f));
    }

    [Test]
    public void NextValue_float_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(_ => (float)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1.02f, 3.04f, 5.06f, 7.08f, 9.1f, 11.12f }));
    }

    [Test]
    public void NextValue_float_values_all_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 100000).Select(_ => (float)nextValue).ToArray();
        Assert.That(values, Is.Ordered.Ascending);
    }
}
