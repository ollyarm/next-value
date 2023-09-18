namespace NextValue;

public static class NextValueCollections
{
    public static T[] Array<T>(this NextValue nextValue, Func<T> create, int count = 3)
        => Enumerable.Range(1, count).Select(_ => create()).ToArray();

    public static List<T> List<T>(this NextValue nextValue, Func<T> create, int count = 3)
        => Enumerable.Range(1, count).Select(_ => create()).ToList();

    public static int[] IntArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (int)nextValue, count);

    public static List<int> IntList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (int)nextValue, count);

    public static string[] StringArray(this NextValue nextValue, int count = 3)
        => nextValue.Array(() => (string)nextValue, count);

    public static List<string> StringList(this NextValue nextValue, int count = 3)
        => nextValue.List(() => (string)nextValue, count);
}
