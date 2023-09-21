namespace NextValues;

public static class NextValueExceptions
{
    public static Exception Exception(this NextValue nextValue) => new Exception($"Exception {(int)nextValue}");
    public static InvalidOperationException InvalidOperationException(this NextValue nextValue) => new InvalidOperationException($"InvalidOperationException {(int)nextValue}");
}
