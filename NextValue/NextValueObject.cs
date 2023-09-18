namespace NextValue;

public static class NextValueObject
{
    public static T New<T>(this NextValue nextValue) where T : class, new() => nextValue.New(new T());
    public static T New<T>(this NextValue nextValue, Func<T> create) where T : class => nextValue.New(create());

    private static T New<T>(this NextValue nextValue, T item) where T : class
    {
        foreach (var p in typeof(T).GetProperties().Where(x => x.CanWrite))
        {
            if (p.PropertyType == typeof(string) && string.IsNullOrEmpty((string)p.GetValue(item)))
            {
                p.SetValue(item, $"{p.Name} {(int)nextValue}");
            }
            else if (p.PropertyType == typeof(int) || p.PropertyType == typeof(int?))
            {
                p.SetValue(item, (int)nextValue);
            }
            else if (p.PropertyType == typeof(decimal) || p.PropertyType == typeof(decimal?))
            {
                p.SetValue(item, (decimal)nextValue);
            }
            else if (p.PropertyType == typeof(double) || p.PropertyType == typeof(double?))
            {
                p.SetValue(item, (double)nextValue);
            }
            else if (p.PropertyType == typeof(float) || p.PropertyType == typeof(float?))
            {
                p.SetValue(item, (float)nextValue);
            }
            else if (p.PropertyType == typeof(bool) || p.PropertyType == typeof(bool?))
            {
                // increment just to be consistent, 
                var _ = (int)nextValue;
                // always return true as false is normally default in any mapping
                // if customizing is required then can be done explicitly
                p.SetValue(item, true);
            }
            else if (p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?))
            {
                p.SetValue(item, (DateTime)nextValue);
            }
            else if (p.PropertyType == typeof(DateTimeOffset) || p.PropertyType == typeof(DateTimeOffset?))
            {
                p.SetValue(item, (DateTimeOffset)nextValue);
            }
            else if (p.PropertyType == typeof(Guid) || p.PropertyType == typeof(Guid?))
            {
                p.SetValue(item, (Guid)nextValue);
            }
            else if (p.PropertyType.IsEnum)
            {
                // presuming enums are int based and never pick a zero
                var values = System.Enum.GetValues(p.PropertyType).Cast<int>().Where(x => x != 0).ToArray();
                var value = values.Any() ? nextValue.From(values) : 0;
                p.SetValue(item, value);
            }
            else if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) && p.PropertyType.GetGenericArguments()[0].IsEnum)
            {
                var enumType = p.PropertyType.GetGenericArguments()[0];
                var nullableType = typeof(Nullable<>).MakeGenericType(enumType);

                // presuming enums are int based and never pick a zero
                var values = Enum.GetValues(enumType).Cast<int>().Where(x => x != 0).ToArray();
                
                var value = values.Any() ? nextValue.From(values) : 0;

                p.SetValue(item, nullableType.GetConstructor(new[] { enumType })!.Invoke(new object[] { value }));
            }

        }
        return item;
    }
}
