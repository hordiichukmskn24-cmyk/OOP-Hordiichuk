namespace Lab12App;

public static class FunctionalUtils
{
    // 1. Map
    public static List<TResult> Map<TSource, TResult>(List<TSource> list, Func<TSource, TResult> mapper)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(mapper);
        var result = new List<TResult>();
        foreach (var item in list) result.Add(mapper(item));
        return result;
    }

    // 2. Filter
    public static List<T> Filter<T>(List<T> list, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(predicate);
        var result = new List<T>();
        foreach (var item in list) if (predicate(item)) result.Add(item);
        return result;
    }

    // 3. GroupBy
    public static Dictionary<TKey, List<T>> GroupBy<T, TKey>(List<T> list, Func<T, TKey> keySelector)
        where TKey : notnull
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(keySelector);
        var groups = new Dictionary<TKey, List<T>>();
        foreach (var item in list)
        {
            TKey key = keySelector(item);
            if (!groups.ContainsKey(key)) groups[key] = new List<T>();
            groups[key].Add(item);
        }
        return groups;
    }

    // 4. OrderBy
    public static List<T> OrderBy<T, TKey>(List<T> list, Func<T, TKey> keySelector)
        where TKey : IComparable<TKey>
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(keySelector);
        var sortedList = new List<T>(list);
        sortedList.Sort((a, b) => keySelector(a).CompareTo(keySelector(b)));
        return sortedList;
    }

    // 5. ThenBy
    public static List<T> ThenBy<T, TKey1, TKey2>(
        List<T> list, 
        Func<T, TKey1> primaryKeySelector, 
        Func<T, TKey2> secondaryKeySelector)
        where TKey1 : IComparable<TKey1>
        where TKey2 : IComparable<TKey2>
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(primaryKeySelector);
        ArgumentNullException.ThrowIfNull(secondaryKeySelector);
        var sortedList = new List<T>(list);
        sortedList.Sort((a, b) =>
        {
            int primaryComparison = primaryKeySelector(a).CompareTo(primaryKeySelector(b));
            return primaryComparison != 0 ? primaryComparison : secondaryKeySelector(a).CompareTo(secondaryKeySelector(b));
        });
        return sortedList;
    }

    // Допоміжний ForEach
    public static void ForEach<T>(List<T> list, Action<T> action)
    {
        ArgumentNullException.ThrowIfNull(list);
        ArgumentNullException.ThrowIfNull(action);
        foreach (var item in list) action(item);
    }
}