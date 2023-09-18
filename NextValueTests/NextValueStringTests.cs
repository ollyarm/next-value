﻿namespace NextValueTests;

using NextValue;

[TestFixture]
public class NextValueStringTests
{

    [Test]
    public void NextValue_string_initial_value_without_seed_is_String_Value_1()
    {
        var nextValue = new NextValue();
        Assert.That((string)nextValue, Is.EqualTo("String Value 1"));
    }

    [Test]
    public void NextValue_string_initial_value_with_seed_has_seed()
    {
        var nextValue = new NextValue(100);
        Assert.That((string)nextValue, Is.EqualTo("String Value 100"));
    }

    [Test]
    public void NextValue_string_values_increase()
    {
        var nextValue = new NextValue();
        var values = Enumerable.Range(1, 6).Select(i => (string)nextValue).ToArray();
        Assert.That(values, Is.EqualTo(new[] { "String Value 1", "String Value 2", "String Value 3", "String Value 4", "String Value 5", "String Value 6" }));
    }

    [Test]
    public void NextValue_string_method_returns_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.String(), Is.EqualTo($"String Value 100"));
    }

    [Test]
    public void NextValue_StringArray_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.StringArray(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Select(i => $"String Value {i}")));
    }

    [Test]
    public void NextValue_StringArray_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.StringArray(), Is.EqualTo(new[] { 1, 2, 3 }.Select(i => $"String Value {i}")));
    }

    [Test]
    public void NextValue_StringList_values_are_ascending()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.StringList(10), Is.EqualTo(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }.Select(i => $"String Value {i}")));

    }

    [Test]
    public void NextValue_StringList_default_has_3_values()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.StringList(), Is.EqualTo(new[] { 1, 2, 3 }.Select(i => $"String Value {i}")));
    }
}
