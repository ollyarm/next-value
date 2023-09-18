namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueDoubleTests
{

    [Test]
    public void NextValue_double_initial_value_without_seed_is_initial()
    {
        var nextValue = new NextValue();
        Assert.That((double)nextValue, Is.EqualTo(1.02d));
    }

    [Test]
    public void NextValue_double_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((double)nextValue, Is.EqualTo(100.01d));
    }

    [Test]
    public void NextValue_double_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(_ => (double)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1.02d, 3.04d, 5.06d, 7.08d, 9.1d, 11.12d }));
    }

    [Test]
    public void NextValue_double_values_all_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 100000).Select(_ => (double)nextValue).ToArray();
        Assert.That(values, Is.Ordered.Ascending);
    }
}
