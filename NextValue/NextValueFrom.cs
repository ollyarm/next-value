namespace NextValue;
using System.Collections.Generic;

public static class NextValueFrom
{
    public static T From<T>(this NextValue next, IEnumerable<T> list)
    {
        var vals = list.ToArray();
        if (!vals.Any()) throw new ArgumentException(nameof(list), "List must have some values to select one from");
        return vals.ElementAt((next.Int() - 1) % vals.Length)!;
    }

    public static T Enum<T>(this NextValue next)
       where T : Enum
    {
        // presuming enums are int based and never pick a zero
        var vals = System.Enum.GetValues(typeof(T)).Cast<int>().Where(x => x != 0);
        if (!vals.Any()) throw new ArgumentException($"Enum must have some values to select one from - '{(T)(object)0}' is ignored");
        var val = next.From<int>(vals);
        return (T)(object)val;
    }
}
