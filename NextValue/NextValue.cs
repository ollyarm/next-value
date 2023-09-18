namespace NextValue;

public class NextValue
{
    private int _seed;
    public NextValue()
    {
        _seed = 1;
    }

    public NextValue(int seed)
    {
        if (seed <= 0) throw new ArgumentOutOfRangeException("Seed must be greater than zero");
        _seed = seed;
    }

    public static implicit operator int(NextValue next) => next._seed++;
    public int Int() => (int)this;

    public static implicit operator string(NextValue next) => $"String Value {(int)next}";
    public string String() => (string)this;
}
