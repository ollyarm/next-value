using Xunit;
using NextValues;

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
