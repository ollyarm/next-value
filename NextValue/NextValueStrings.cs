namespace NextValues;

public static class NextValueStrings
{
    public static string StringOfLength(this NextValue next, int length) => "".PadLeft(length, next);
    public static string NumericStringOfLength(this NextValue next, int length)
    {
        var val = ((int)next).ToString();
        var times = (length / val.Length) + 2;
        var result = string.Join(val, new string[times]);
        return result[..length];
    }
}
