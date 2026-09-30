namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal partial class CA
{
    /// <summary>
    /// Remove which contains list.
    /// </summary>
    internal static void RemoveWhichContainsList(List<string> files, List<string> list, bool isWildcard, Func<string, string, bool>? wildcardIsMatch = null)
    {
        foreach (var item in list)
        {
            RemoveWhichContains(files, item, isWildcard, wildcardIsMatch);
        }
    }

    /// <summary>
    /// Join i list.
    /// </summary>
    internal static List<T> JoinIList<T>(params IList<T>[] lists)
    {
        var result = new List<T>();
        foreach (var list in lists)
        {
            foreach (var element in list)
            {
                result.Add((T)element);
            }
        }

        return result;
    }

    /// <summary>
    /// Wrap with.
    /// </summary>
    internal static List<string> WrapWith(List<string> list, string wrapText)
        => WrapWith(list, wrapText, wrapText);

    /// <summary>
    /// Wrap with.
    /// </summary>
    internal static List<string> WrapWith(List<string> list, string prefixText, string suffixText)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = prefixText + list[i] + suffixText;
        }

        return list;
    }

    /// <summary>
    /// Ensure backslash.
    /// </summary>
    internal static List<string> EnsureBackslash(List<string> paths)
    {
        for (int i = 0; i < paths.Count; i++)
        {
            string path = paths[i];
            if (path[path.Length - 1] != '\\')
            {
                paths[i] = path + "\\";
            }
        }

        return paths;
    }

    /// <summary>
    /// Contains element.
    /// </summary>
    internal static bool ContainsElement<T>(IList<T> list, T element)
    {
        if (list.Count == 0)
        {
            return false;
        }

        foreach (T item in list)
        {
            if (Comparer<T>.Equals(item, element))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Remove wildcard.
    /// </summary>
    internal static void RemoveWildcard(List<string> list, string mask)
    {
        //https://stackoverflow.com/a/15275806
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (SH.MatchWildcard(list[i], mask))
            {
                list.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Prepend.
    /// </summary>
    internal static List<string> Prepend(string prefix, List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].StartsWith(prefix))
            {
                list[i] = prefix + list[i];
            }
        }

        return list;
    }

    /// <summary>
    /// To list string.
    /// </summary>
    internal static List<string> ToListString(params string[] values)
        => values.ToList();
}
