namespace NextValue;

public static class NextValueCollections
{
    public static T[] Array<T>(this NextValue nextValue, Func<T> create, int count = 3)
        => Enumerable.Range(1, count).Select(_ => create()).ToArray();

    public static T[] Array<T>(this NextValue nextValue, int count = 3) where T : class, new()
        => nextValue.Array(() => nextValue.New<T>(), count);

    public static List<T> List<T>(this NextValue nextValue, Func<T> create, int count = 3)
        => Enumerable.Range(1, count).Select(_ => create()).ToList();

    public static List<T> List<T>(this NextValue nextValue, int count = 3) where T : class, new()
        => nextValue.List(() => nextValue.New<T>(), count);

    public static int[] IntArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (int)nextValue, count);

    public static List<int> IntList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (int)nextValue, count);

    public static string[] StringArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (string)nextValue, count);

    public static List<string> StringList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (string)nextValue, count);

    public static decimal[] DecimalArray(this NextValue nextValue, int count = 3)
    => nextValue.Array(() => (decimal)nextValue, count);

    public static List<decimal> DecimalList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (decimal)nextValue, count);

    public static Guid[] GuidsArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (Guid)nextValue, count);

    public static List<Guid> GuidsList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (Guid)nextValue, count);

    public static DateTime[] DateTimeArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (DateTime)nextValue, count);

    public static List<DateTime> DateTimeList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (DateTime)nextValue, count);

    public static DateTimeOffset[] DateTimeOffsetArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (DateTimeOffset)nextValue, count);

    public static List<DateTimeOffset> DateTimeOffsetList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (DateTimeOffset)nextValue, count);
}
