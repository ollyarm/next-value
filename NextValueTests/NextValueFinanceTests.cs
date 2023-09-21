namespace NextValueTests;

using NextValues;

[TestFixture]
public class NextValueFinanceTests
{
    [Test]
    public void NextValue_CashAmount_initital_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.CashAmount(), Is.EqualTo(1.02m));
    }

    [Test]
    public void NextValue_CashAmount_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.CashAmount(), Is.EqualTo(100.01m));
    }

    [Test]
    public void NextValue_CashAmount_values_ascend_without_round_numbers()
    {
        var nextValue = new NextValue(95);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.CashAmount()), Is.EqualTo(new[] { 
            95.96m, 
            97.98m, 
            99.99m, 
            101.02m,
            103.04m, 
            105.06m, 
            107.08m, 
            109.10m,
            111.12m, 
            113.14m,
        }));
    }

    [Test]
    public void NextValue_SortCode_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.SortCode(), Is.EqualTo("112233"));
    }

    [Test]
    public void NextValue_SortCode_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.SortCode(), Is.EqualTo("001122"));
    }

    [Test]
    public void NextValue_SortCode_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.SortCode()), Is.EqualTo(new[] { "556677", "889900", "112233", "445566", "778899", "001122", "334455", "667788", "990011", "223344", }));
    }

    [Test]
    public void NextValue_AccountNumber_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.AccountNumber(), Is.EqualTo("12345678"));
    }

    [Test]
    public void NextValue_AccountNumber_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.AccountNumber(), Is.EqualTo("01234567"));
    }

    [Test]
    public void NextValue_AccountNumber_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.AccountNumber()), Is.EqualTo(new[] { "56789012", "34567890", "12345678", "90123456", "78901234", "56789012", "34567890", "12345678", "90123456", "78901234", }));
    }

    [Test]
    public void NextValue_BBan_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.BBan(), Is.EqualTo("ABCD55667789012345"));
    }

    [Test]
    public void NextValue_BBan_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.BBan(), Is.EqualTo("VWXY44556678901234"));
    }

    [Test]
    public void NextValue_BBan_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.BBan()), Is.EqualTo(new[] { "OPQR99001123456789", "DEFG44556678901234", "STUV99001123456789", "HIJK44556678901234", "WXYZ99001123456789", "LMNO44556678901234", "ABCD99001123456789", "PQRS44556678901234", "EFGH99001123456789", "TUVW44556678901234", }));
    }

    [Test]
    public void NextValue_IBan_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.IBan(), Is.EqualTo("GB75ABCD55667789012345"));
    }

    [Test]
    public void NextValue_IBan_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.IBan(), Is.EqualTo("GB68VWXY44556678901234"));
    }


    [Test]
    public void NextValue_IBan_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.IBan()), Is.EqualTo(new[] { 
            "GB98OPQR99001123456789", 
            "GB54DEFG44556678901234", 
            "GB58STUV99001123456789", 
            "GB14HIJK44556678901234", 
            "GB18WXYZ99001123456789", 
            "GB71LMNO44556678901234", 
            "GB44ABCD99001123456789", 
            "GB31PQRS44556678901234", 
            "GB04EFGH99001123456789", 
            "GB88TUVW44556678901234", 
        }));
    }

    [Test]
    public void NextValue_Bic_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.Bic(), Is.EqualTo("ABCDGB05"));
    }

    [Test]
    public void NextValue_Bic_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.Bic(), Is.EqualTo("VWXYGB04"));
    }

    [Test]
    public void NextValue_Bic_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.Bic()), Is.EqualTo(new[] {
            "OPQRGB19",
            "TUVWGB24",
            "YZABGB29",
            "DEFGGB34",
            "IJKLGB39",
            "NOPQGB44",
            "STUVGB49",
            "XYZAGB54",
            "CDEFGB59",
            "HIJKGB64",
        }));
    }

    [Test]
    public void NextValue_LEI_initial_value()
    {
        var nextValue = new NextValue();
        Assert.That(nextValue.LEI(), Is.EqualTo("111100BBBBBBBBBBBB33"));
    }

    [Test]
    public void NextValue_LEI_with_seed_value()
    {
        var nextValue = new NextValue(100);
        Assert.That(nextValue.LEI(), Is.EqualTo("100100WWWWWWWWWWWW10"));
    }

    [Test]
    public void NextValue_LEI_values_increase_seed()
    {
        var nextValue = new NextValue(15);
        Assert.That(Enumerable.Range(1, 10).Select(_ => nextValue.LEI()), Is.EqualTo(new[] {
            "151500PPPPPPPPPPPP17",
            "181800SSSSSSSSSSSS20",
            "212100VVVVVVVVVVVV23",
            "242400YYYYYYYYYYYY26",
            "272700BBBBBBBBBBBB29",
            "303000EEEEEEEEEEEE32",
            "333300HHHHHHHHHHHH35",
            "363600KKKKKKKKKKKK38",
            "393900NNNNNNNNNNNN41",
            "424200QQQQQQQQQQQQ44",
        }));
    }
}
