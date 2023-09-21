using NextValues;
using Xunit;

public class XUnitBaseClassSetup : XUnitTestBase
{
    [Fact]
    public void Test()
    {
        var example = NextValue.IntArray(10);

        Assert.Equal(example, new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
    }
}

public abstract class XUnitTestBase
{
    protected NextValue NextValue { get; private set; }

    public XUnitTestBase()
    {
        NextValue = new();
    }
}

