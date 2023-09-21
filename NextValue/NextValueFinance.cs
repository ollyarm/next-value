namespace NextValues;

using System.Numerics;
using static System.Net.Mime.MediaTypeNames;

public static class NextValueFinance
{
    public static decimal CashAmount(this NextValue next)
    {
        var result = decimal.Round(next, 2, MidpointRounding.AwayFromZero);
        if (result % 1 == 0)
        {
            result += 0.01m;
        }
        return result;
    }

    public static string Bic(this NextValue next) => $"{next.BankCode()}GB{(int)next % 100:D2}";

    public static string IBan(this NextValue next)
    {
        var countryCode = "GB";
        var bankCode = next.BankCode();
        var sortCode = next.SortCode();
        var accountNumber = next.AccountNumber();

        var checksum = CalculateChecksum(countryCode, bankCode, sortCode, accountNumber);

        return $"{countryCode}{checksum}{bankCode}{sortCode}{accountNumber}";
    }


    private static string CalculateChecksum(string countryCode, string bankCode, string sortCode, string accountNumber)
    {
        // This class calculates a new checksum using the formula explained here: https://iban.co.uk/generation.html
        // Without such the Iban is not valid

        var convertedCountryCode = ConvertIbanLettersToNumericValue(countryCode);
        var convertedBankCode = ConvertIbanLettersToNumericValue(bankCode);

        var convertedIbanAsString = string.Concat(convertedBankCode, sortCode, accountNumber, convertedCountryCode, "00");
        var convertedIbanAsInt = BigInteger.Parse(convertedIbanAsString);
        var calculatedChecksum = 98 - convertedIbanAsInt % 97;

        return calculatedChecksum.ToString().PadLeft(2, '0');
    }

    private static string ConvertIbanLettersToNumericValue(string letters)
    {
        // this offset makes A to Z become 10 to 35
        var convertedLetters = letters.ToCharArray().Select(letter => letter - (letter >= 65 ? 55 : 0)).ToArray();
        return string.Join("", convertedLetters);
    }

    // 4 chars for bank code then 6 numbers for sort code then 8 numbers for account number
    public static string BBan(this NextValue next) => next.BankCode() + next.SortCode() + next.AccountNumber();

    public static string BankCode(this NextValue next) => string.Concat(next.Array(() => (char)next, 4));

    public static string SortCode(this NextValue next) => string.Concat(next.Array(() => (int)next % 10, 3).SelectMany(i => new[] { i, i }));

    public static string AccountNumber(this NextValue next) => string.Concat(next.Array(() => (int)next % 10, 8));

    public static string LEI(this NextValue next) => $"{next.NumericStringOfLength(4)}00{next.StringOfLength(12).ToUpper()}{next.NumericStringOfLength(2)}";
}
