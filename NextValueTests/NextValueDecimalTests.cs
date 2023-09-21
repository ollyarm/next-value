namespace NextValueTests;

using NextValues;

[TestFixture]
public class NextValueDecimalTests
{

    [Test]
    public void NextValue_decimal_initial_value_without_seed_is_initial()
    {
        var nextValue = new NextValue();
        Assert.That((decimal)nextValue, Is.EqualTo(1.02m));
    }

    [Test]
    public void NextValue_decimal_initial_value_with_seed_is_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((decimal)nextValue, Is.EqualTo(100.01m));
    }

    [Test]
    public void NextValue_decimal_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(_ => (decimal)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1.02m, 3.04m, 5.06m, 7.08m, 9.1m, 11.12m }));
    }

    [Test]
    public void NextValue_decimal_method_returns_value()
    {
        var nextValue = new NextValue(999);
        Assert.That(nextValue.Decimal(), Is.EqualTo(999.99m));
    }

    [Test]
    public void NextValue_DecimalArray_values_are_ascending()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.DecimalArray(10), Is.EqualTo(new[] {
            100.01m,
            102.03m,
            104.05m,
            106.07m,
            108.09m,
            110.11m,
            112.13m,
            114.15m,
            116.17m,
            118.19m,
        }));
    }

    [Test]
    public void NextValue_DecimalArray_values_are_all_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DecimalArray(100000), Is.Ordered.Ascending);
    }

    [Test]
    public void NextValue_DecimalArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DecimalArray(), Is.EqualTo(new[] { 1.02m, 3.04m, 5.06m }));
    }

    [Test]
    public void NextValue_DecimalList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DecimalList(10), Is.EqualTo(new[] { 1.02m, 3.04m, 5.06m, 7.08m, 9.1m, 11.12m, 13.14m, 15.16m, 17.18m, 19.2m }));

    }

    [Test]
    public void NextValue_DecimalList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.DecimalList(), Is.EqualTo(new[] { 1.02m, 3.04m, 5.06m }));
    }

}
