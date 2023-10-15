namespace NextValueTests;

using NextValues;

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

    [Test]
    public void NextValue_IntArray_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.IntArray(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));

    }

    [Test]
    public void NextValue_IntArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.IntArray(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void NextValue_IntList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.IntList(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }));

    }

    [Test]
    public void NextValue_IntList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.IntList(), Is.EqualTo(new[] { 1, 2, 3 }));
    }

    [Test]
    public void NextValue_Reset_next_int_is_1()
    {
        var nextValue = new NextValue(100);
        var int1 = (int)nextValue;
        var int2 = (int)nextValue.Reset();

        Assert.That(int1, Is.EqualTo(100));
        Assert.That(int2, Is.EqualTo(1));
    }

    [Test]
    public void NextValue_Reset_with_value_next_int_is_value()
    {
        var nextValue = new NextValue(100);
        var int1 = (int)nextValue;
        var int2 = (int)nextValue.Reset(255);

        Assert.That(int1, Is.EqualTo(100));
        Assert.That(int2, Is.EqualTo(255));
    }
}
