using NUnit.Framework;
using NextValues;

[TestFixture]
public class BuilderExamples
{
    [Test]
    public void Test()
    {
        var nextValue = new NextValue();
        var example1 = nextValue.ComplexObject(b => b.WithName("Example Name").WithAmount(100));
        var example2 = nextValue.ComplexObject(b => b.WithName("Another Example"));
        var example3 = nextValue.ComplexObject();

        Assert.Multiple(() =>
        {
            Assert.That(example1.Name, Is.EqualTo("Example Name"));
            Assert.That(example1.Amount, Is.EqualTo(100));
            Assert.That(example2.Name, Is.EqualTo("Another Example"));
            Assert.That(example2.Amount, Is.EqualTo(1.02m));
            Assert.That(example3.Name, Is.EqualTo("String Value 3"));
            Assert.That(example3.Amount, Is.EqualTo(4.05m));
        });
    }
}
public static class BuilderExtentions
{
    public static ExampleComplexObject ComplexObject(this NextValue nextValue, Action<Builder>? build = null)
    {
        var builder = new Builder(nextValue);
        build ??= (b) => { };
        build(builder);
        return builder.Build();
    }
}

public class Builder
{
    private string? _name;
    private decimal? _amount;
    private readonly NextValue _nextValue;

    public Builder(NextValue nextValue)
    {
        this._nextValue = nextValue;
    }

    public Builder WithName(string name)
    {
        _name = name;
        return this;
    }

    public Builder WithAmount(decimal amount)
    {
        _amount = amount;
        return this;
    }

    public ExampleComplexObject Build()
    {
        return new ExampleComplexObject(
            _name ?? _nextValue,
            _amount ?? _nextValue
            );
    }
}

public class ExampleComplexObject
{
    public ExampleComplexObject(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public string Name { get; }
    public decimal Amount { get; }
}
