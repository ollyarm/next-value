namespace NextValueTests;

using NextValues;

[TestFixture]
public class NextValueCharTests
{

    [Test]
    public void NextValue_char_initial_value_without_seed_is_a()
    {
        var nextValue = new NextValue();
        Assert.That((char)nextValue, Is.EqualTo('A'));
    }

    [Test]
    public void NextValue_char_initial_value_with_seed_has_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((char)nextValue, Is.EqualTo('V'));
    }

    [Test]
    public void NextValue_char_values_increase()
    {
        var nextValue = new NextValue(20);
        var values = Enumerable.Range(1, 10).Select(i => (char)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'A', 'B', 'C', })); ;
    }

    [Test]
    public void NextValue_char_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.Char(), Is.EqualTo('V'));
    }
}
