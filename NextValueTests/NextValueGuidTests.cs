namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueGuidTests
{
    [Test]
    public void NextValue_guid_initial_value_without_seed_is_String_Value_1()
    {
        var nextValue = new NextValue();
        Assert.That((Guid)nextValue, Is.EqualTo(Guid.Parse("00000000000000000000000000000001")));
    }

    [Test]
    public void NextValue_guid_initial_value_with_seed_uses_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((Guid)nextValue, Is.EqualTo(Guid.Parse("00000000000000000000000000000100")));
    }

    [Test]
    public void NextValue_guid_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.Guid(), Is.EqualTo(Guid.Parse("00000000000000000000000000000100")));
    }

    [Test]
    public void NextValue_guid_list_returns_ascending_values()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.GuidsList(), Is.EqualTo(new List<Guid>{
            Guid.Parse("00000000000000000000000000000100"),
            Guid.Parse("00000000000000000000000000000101"),
            Guid.Parse("00000000000000000000000000000102"),
        }));
    }

    [Test]
    public void NextValue_guid_list_with_number_returns_ascending_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.GuidsList(2), Is.EqualTo(new List<Guid>{
            Guid.Parse("00000000000000000000000000000001"),
            Guid.Parse("00000000000000000000000000000002"),
        }));
    }

    [Test]
    public void NextValue_guid_array_returns_ascending_values()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.GuidsArray(), Is.EqualTo(new List<Guid>{
            Guid.Parse("00000000000000000000000000000100"),
            Guid.Parse("00000000000000000000000000000101"),
            Guid.Parse("00000000000000000000000000000102"),
        }));
    }

    [Test]
    public void NextValue_guid_array_with_number_returns_ascending_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.GuidsArray(2), Is.EqualTo(new List<Guid>{
            Guid.Parse("00000000000000000000000000000001"),
            Guid.Parse("00000000000000000000000000000002"),
        }));
    }
}