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
    public static string AccountNumber(this NextValue nextValue) => $"{nextValue.StringOfLength(2)}00{nextValue.NumericStringOfLength(6)}";

    public static Customer NewCustomer(this NextValue nextValue)
    {
        return new Customer(nextValue, $"Customer {(int)nextValue}");
    }

    public static Account NewAccount(this NextValue nextValue, Customer? customer = null, string? accountNumber = null)
    {
        customer ??= nextValue.NewCustomer();
        
        return new Account(customer, accountNumber ?? nextValue.AccountNumber(), nextValue);

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