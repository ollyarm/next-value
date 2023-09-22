namespace NextValues;

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

    public static implicit operator char(NextValue next) => (char)((next.Int() - 1) % 26 + 65);
    public char Char() => (char)this;

    public static implicit operator Guid(NextValue next)
    {
        var stringValue = ((int)next).ToString("D32");
        return System.Guid.Parse(stringValue);
    }

    public Guid Guid() => (Guid)this;

    private static readonly DateTime _dateSeed = System.DateTime.Parse("1900-01-01 12:00:00");
    private static readonly long _dateGap = TimeSpan.Parse("06:12:24").Ticks;
    public static implicit operator DateTime(NextValue next)
    {
        var ticks = _dateGap * (int)next;
        return System.DateTime.SpecifyKind(_dateSeed.AddTicks(ticks), DateTimeKind.Utc);
    }

    public DateTime DateTime() => (DateTime)this;

    public static implicit operator DateTimeOffset(NextValue next)
    {
        var date = (DateTime)next;
        var offset = (((int)next) % 24 - 12);
        return ((DateTimeOffset)date).ToOffset(TimeSpan.FromHours(offset));
    }

    public DateTimeOffset DateTimeOffset() => (DateTimeOffset)this;

    public static implicit operator decimal(NextValue next)
    {
        var intPart = (decimal)next.Int();
        var decimalPart = ((decimal) next.Int() / 100) % 1;
        // if decimal part is round number then convert int part to decimal part
        if(decimalPart == 0m)
        {
            decimalPart = (intPart / 100) % 1;;
        }
        return intPart + decimalPart;
    }
    public decimal Decimal() => (decimal)this;

    public static implicit operator double(NextValue next) => (double)(decimal)next;
    public static implicit operator float(NextValue next) => (float)(decimal)next;

}
