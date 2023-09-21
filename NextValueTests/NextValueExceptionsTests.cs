namespace NextValueTests;

using NextValues;

[TestFixture]
public class NextValueExceptionsTests
{
    [Test]
    public void NextValue_exception_has_message()
    {
        var nextValue = new NextValue();
        var exception = nextValue.Exception();

        Assert.That(exception.Message, Is.EqualTo("Exception 1"));
    }

    [Test]
    public void NextValue_invalid_operation_exception_has_message()
    {
        var nextValue = new NextValue(10);
        var exception = nextValue.InvalidOperationException();

        Assert.That(exception.Message, Is.EqualTo("InvalidOperationException 10"));
    }

}
