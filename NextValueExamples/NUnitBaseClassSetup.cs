using NUnit.Framework;
using NextValues;

[TestFixture]
public class NUnitBaseClassSetup : NUnitTestBase
{
    [Test]
    public void Test()
    {
        var example = NextValue.IntList(100);

        Assert.That(example, Has.Count.EqualTo(100).And.Ordered.Ascending);
    }
}

public abstract class NUnitTestBase
{
    protected NextValue NextValue { get; private set; }

    [SetUp]
    public void SetUpBase()
    {
        NextValue = new NextValue();
    }
}

