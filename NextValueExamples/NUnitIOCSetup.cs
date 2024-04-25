using Microsoft.Extensions.DependencyInjection;
using NextValues;
using NUnit.Framework;

[TestFixture]
public class NUnitIOCSetup : NUnitIOCTestBase
{
    [Test]
    public void Test()
    {
        var example = NextValue.DateTimeOffsetArray();

        Assert.That(example, Has.Length.EqualTo(3).And.Ordered.Ascending);
    }
}

public abstract class NUnitIOCTestBase
{
    protected NextValue NextValue { get; private set; }


    [SetUp]
    public void SetUpBase()
    {
        var services = Tests.ServiceProvider.CreateScope().ServiceProvider;
        NextValue = services.GetRequiredService<NextValue>();
    }
}

[SetUpFixture]
public static class Tests
{
    public static ServiceProvider ServiceProvider;

    [OneTimeSetUp]
    public static void OneTimeSetup()
    {
        ServiceProvider = new ServiceCollection()
            .AddScoped<NextValue>()
            .BuildServiceProvider();
    }

    [OneTimeTearDown]
    public static void OneTimeTearDown()
    {
        ServiceProvider?.Dispose();
    }
}