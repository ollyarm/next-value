namespace NextValueTests;

using NUnit.Framework;

[TestFixture]
public class Example
{
    [Test]
    public void ShouldPass()
    {
        Assert.Pass("Should Pass");
    }

    [Test]
    public void ShouldFail()
    {
        Assert.Fail("Should Fail");
    }
}
