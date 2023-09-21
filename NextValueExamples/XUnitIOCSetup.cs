using Microsoft.Extensions.DependencyInjection;
using NextValues;
using Xunit;

[Collection("IOC Setup")]
public class XUnitIOCSetup : XUnitIOCTestBase
{
    public XUnitIOCSetup(IOCFixture iocFixture)
        : base(iocFixture)
    {
        
    }

    [Fact]
    public void Test()
    {
        var example = NextValue.IntArray(5);

        Assert.Equal(new[] { 1, 2, 3, 4, 5}, example);
    }
}

public abstract class XUnitIOCTestBase
{
    protected NextValue NextValue { get; private set; }

    public XUnitIOCTestBase(IOCFixture iOCFixture)
    {

        var services = iOCFixture.ServiceProvider.CreateScope().ServiceProvider;
        NextValue = services.GetRequiredService<NextValue>();
    }
}

public class IOCFixture
{
    public IServiceProvider ServiceProvider { get; }

    public IOCFixture()
    {
        ServiceProvider = new ServiceCollection()
            .AddScoped<NextValue>()
            .BuildServiceProvider();
    }
}

[CollectionDefinition("IOC Setup")]
public class IOCFixtureCollection : ICollectionFixture<IOCFixture> { }
