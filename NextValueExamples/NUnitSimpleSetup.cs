using NUnit.Framework;
using NextValues;

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
        public decimal Amount { get; set; }
        public DateTime Created { get; set; }
    }
}
