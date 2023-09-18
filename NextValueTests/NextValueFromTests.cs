namespace NextValueTests;

using NextValue;

public class NextValueFromTests
{
    [Test]
    public void NextValue_From_initial_value_without_seed_is_first_value()
    {
        var options = Enumerable.Range(1, 10).ToArray();
        var nextValue = new NextValue();
        Assert.That(nextValue.From(options), Is.EqualTo(1));

    }

    [Test]
    public void NextValue_From_initial_value_with_seed_has_seed_value()
    {
        var options = Enumerable.Range(1, 10).ToArray();
        var nextValue = new NextValue(102);
        Assert.That(nextValue.From(options), Is.EqualTo(2));
    }

    [Test]
    public void NextValue_From_values_have_index_increasing()
    {
        var options = Enumerable.Range(1, 10).ToArray();
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 3).Select(i => nextValue.From(options)).ToArray();
        Assert.That(values, Is.EqualTo(new[] { 1, 2, 3 }));

    }

    [Test]
    public void NextValue_From_when_options_are_empty_expect_exception()
    {
        var options = Array.Empty<int>();
        var nextValue = new NextValue();
        Assert.That(() => nextValue.From(options), Throws.ArgumentException.With.Message.Match("List must have some values to select one from"));
    }

    [Test]
    public void NextValue_Enum_initial_value_without_seed_is_first_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.Enum<TestEnum>(), Is.EqualTo(TestEnum.One));
    }

    [Test]
    public void NextValue_Enum_initial_value_with_seed_is_seed_value()
    {
        var nextValue = new NextValue(102);
        Assert.That(nextValue.Enum<TestEnum>(), Is.EqualTo(TestEnum.Two));
    }

    [Test]
    public void NextValue_Enum_values_have_index_increasing()
    {
        var nextValue = new NextValue(2);
        var values = Enumerable.Range(1, 6).Select(i => nextValue.Enum<TestEnum>()).ToArray();
        Assert.That(values, Is.EqualTo(new[] { TestEnum.Two, TestEnum.Three, TestEnum.Ten, TestEnum.One, TestEnum.Two, TestEnum.Three }));

    }


    [Test]
    public void NextValue_Enum_when_values_are_empty_expect_exception()
    {
        var nextValue = new NextValue();
        Assert.That(() => nextValue.Enum<TestEmptyEnum>(), Throws.ArgumentException.With.Message.Match("Enum must have some values to select one from - 'Unknown' is ignored"));
    }

    private enum TestEmptyEnum
    {
        Unknown = 0,
    }

    private enum TestEnum
    {
        Unknown = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Ten = 10,
    }
}
