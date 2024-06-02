# next-value

A very simple library for setting up predictable test data and not based on any randomisation like Guids

- Each value is different.

However

- Test data is exactly the same for every test run in every environment.

## Download & Install

### NuGet
```powershell
Install-Package NextValue
```
### Command Line
```powershell
dotnet add package NextValue
```

## Creating Data

### Ints
```csharp
    nextValue.Int();
    // or
    (int) nextValue;
```

### Strings
```csharp
    nextValue.String();
    // or
    (string) nextValue;
    // or
    nextValue.Char();
    // or
    (char) nextValue;
    // or
    nextValue.StringOfLength(10);
    // or
    nextValue.NumericStringOfLength(10);
```

### Decimals, Doubles, Floats
```csharp
    nextValue.Double();
    // or
    (decimal) nextValue;
    // or
    (double) nextValue;
    // or
    (float) nextValue;
```

### Dates
```csharp
    nextValue.DateTime();
    // or
    nextValue.DateTimeOffset();
    // or
    nextValue.DateOnly();
    // or
    nextValue.TimeOnly();
    // or
    (DateTime) nextValue;
    // or
    (DateTimeOffset) nextValue;
    // or
    (DateOnly) nextValue;
    // or
    (TimeOnly) nextValue;
```

### Guids
```csharp
    nextValue.Guid();
    // or
    (guid) nextValue;
```

### Collections
```csharp
    //defaults to 3 items if number not specified as do following
    nextValue.IntArray(); 
    // or
    nextValue.IntArray(10);
    // or
    nextValue.IntList();
    // or
    nextValue.StringArray();
    // or
    nextValue.StringList();
    // or
    nextValue.GuidArray();
    // or
    nextValue.GuidList();
    // or
    nextValue.DecimalArray();
    // or
    nextValue.DecimalList();
    // or
    nextValue.DateTimeArray();
    // or
    nextValue.DateTimeList();
    // or
    nextValue.DateTimeOffsetArray();
    // or
    nextValue.DateTimeOffsetList();
    // or
    nextValue.Array<Example>();
    // or
    nextValue.List<Example>();
    // or
    nextValue.Array(() => new Example());
    // or
    nextValue.List(10, () => new Example());
```
### Objects
```csharp
    nextValue.New<Example>();
    // or
    nextValue.New(() => new SealedExample(nextValue));
    // or
    nextValue.Array(10, () => new SealedExample(nextValue));
    // or
    nextValue.List(10, () => new SealedExample(nextValue));

    public class Example
    {
        public string Name {get; set; }
        public int ExampleId {get; set; }
        public decimal ExampleValue {get; set; }
    }    

    public class SealedExample
    {
        public SealedExample(string input)
        {
            Input = input;
        }

        public string Input { get; }
    }
```
### Enums
```csharp

    nextValue.Enum<Options>();

    public enum Options()
    {
        Unknown = 0,
        Option1 = 10,
        Option2 = 20,
        Option3 = 30,
    }
```

NB: There is a convention to never pick an enum with a value of 0.
### Options
```csharp
    nextValue.From(new[]{ "Option1", "Option2", "Option3",  });
```

### Finance
```csharp
    nextValue.IBan();
    nextValue.Bic();
    nextValue.BBan();
    nextValue.SortCode();
    nextValue.AccountNumber();
    nextValue.LEI();
```

## Extending

NextValue is very easy to extend with your own customisations no matter how complex your data requirements are.

### Extend using extension methods
```csharp
using NextValues;
using NUnit.Framework;

[TestFixture]
public class ExtensionExamples
{
    [Test]
    public void Test()
    {
        var nextValue = new NextValue();

        var customer = nextValue.NewCustomer();
        var account1 = nextValue.NewAccount(customer);
        var account2 = nextValue.NewAccount(accountNumber: "XX00999999");
        var account3 = nextValue.NewAccount(customer);

        Assert.Multiple(() =>
        {
            Assert.That(account1.Customer, Is.Not.EqualTo(account2.Customer));
            Assert.That(account1.Customer, Is.EqualTo(account3.Customer));
            Assert.That(account1.AccountNumber, Is.EqualTo("CC00444444"));
            Assert.That(account2.AccountNumber, Is.EqualTo("XX00999999"));
            Assert.That(account3.AccountNumber, Is.EqualTo("KK00121212"));
        });
    }
}

public static class NextValueExtensionExamples
{
    public static string AccountNumber(this NextValue nextValue) 
        => $"{nextValue.StringOfLength(2)}00{nextValue.NumericStringOfLength(6)}";

    public static Customer NewCustomer(this NextValue nextValue)
    {
        return new Customer(nextValue, $"Customer {(int)nextValue}");
    }

    public static Account NewAccount(this NextValue nextValue, 
        Customer? customer = null, 
        string? accountNumber = null
        )
    {
        return new Account(
            customer ?? nextValue.NewCustomer(), 
            accountNumber ?? nextValue.AccountNumber(),
            nextValue
            );

    }

    public class Account
    {
        public Account(Customer customer, string accountNumber, decimal ballance)
        {
            Customer = customer;
            AccountNumber = accountNumber;
            Ballance = ballance;
        }

        public Customer Customer { get; }
        public string AccountNumber { get; }
        public decimal Ballance { get; }
    }

    public class Customer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
```

### Extending with a builder

```csharp
using NUnit.Framework;
using NextValues;

[TestFixture]
public class BuilderExamples
{
    [Test]
    public void Test()
    {
        var nextValue = new NextValue();
        
        var example1 = nextValue.ComplexObject(b => b
            .WithName("Example Name")
            .WithAmount(100)
            );

        var example2 = nextValue.ComplexObject(b => b
            .WithName("Another Example")
            );

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
public static class BuilderExtensions
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
```

## Set up

Best way to set up probably depends on how you set up your other test dependencies, however here are some examples.

In principle create a new instance for every test.

### At its simplest

#### NUnit
```csharp
using NextValues;
using NUnit.Framework;

[TestFixture]
public class NUnitSimpleSetup
{
    [Test]
    public void Test()
    {
        var nextValue = new NextValue();

        var example = nextValue.New<Example>();

        Assert.Multiple(() =>
        {
            Assert.That(example.Id, Is.EqualTo(Guid.Parse("00000000-0000-0000-0000-000000000001")));
            Assert.That(example.Name, Is.EqualTo("Name 2"));
            Assert.That(example.Amount, Is.EqualTo(3.04m));
            Assert.That(example.Created, Is.EqualTo(DateTime.Parse("1900-01-02 19:02:00")));
        });
    }

    public class Example
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public double Amount { get; set; }
        public DateTime Created { get; set; }
    }
}
```

#### XUnit
```csharp
using NextValues;
using Xunit;

public class XUnitSimpleSetup
{
    [Fact]
    public void Test()
    {
        var nextValue = new NextValue();

        var example = nextValue.New<Example>();

        Assert.Multiple(
            () => Assert.Equal(Guid.Parse("00000000-0000-0000-0000-000000000001"), example.Id),
            () => Assert.Equal("Name 2", example.Name),
            () => Assert.Equal(3.04m, example.Amount),
            () => Assert.Equal(DateTime.Parse("1900-01-02 19:02:00"), example.Created)
        );
    }

    public class Example
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
    }
}
```

### Using Base Class Setup

#### NUnit
```csharp
using NextValues;
using NUnit.Framework;

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
```

#### XUnit
```csharp
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

```
### Using Dependency Injection
#### NUnit
```csharp
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
    public static IServiceProvider ServiceProvider;

    [OneTimeSetUp]
    public static void OneTimeSetup()
    {
        ServiceProvider = new ServiceCollection()
            .AddScoped<NextValue>()
            .BuildServiceProvider();
    }
}
````

#### XUnit
```csharp
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
````

If a instance must be shared across tests (for example in a component test api setup)
Reset can be called to reinitalise before each test.
```csharp
    nextValue.Reset();
    // or
    nextValue.Reset(100);
```
