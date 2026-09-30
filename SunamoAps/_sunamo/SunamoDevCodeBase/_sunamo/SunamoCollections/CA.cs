namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal partial class CA
{

    /// <summary>
    /// Return which contains indexes.
    /// </summary>
    internal static List<int> ReturnWhichContainsIndexes(string text, IList<string> terms)
    {
        var result = new List<int>();
        var i = 0;
        foreach (var term in terms)
        {
            if (text.Contains(term))
                result.Add(i);
            i++;
        }

        return result;
    }

    /// <summary>
    /// Postfix if not ending.
    /// </summary>
    internal static List<string> PostfixIfNotEnding(string prefix, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = prefix + list[i];
        return list;
    }

    /// <summary>
    /// Split.
    /// </summary>
    internal static List<List<string>> Split(List<string> list, string delimiter)
    {
        var result = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach (var item in list)
            if (item == delimiter)
            {
                result.Add(currentGroup);
                currentGroup.Clear();
            }

        return result;
    }

    /// <summary>
    /// Remove strings empty trim before.
    /// </summary>
    internal static List<string> RemoveStringsEmptyTrimBefore(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (list[i].Trim() == string.Empty)
                list.RemoveAt(i);
        return list;
    }

    /// <summary>
    /// Contains any from element bool.
    /// </summary>
    internal static bool ContainsAnyFromElementBool(string text, IList<string> list)
    {
        if (list.Count == 1 && list.First() == "*")
            return true;
        foreach (var item in list)
            if (text.Contains(item))
                return true;
        return false;
    }

    /// <summary>
    /// Trim.
    /// </summary>
    internal static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
        return list;
    }

    /// <summary>
    /// Remove which contains.
    /// </summary>
    internal static void RemoveWhichContains(List<string> list, string pattern, bool isWildcard, Func<string, string, bool>? wildcardIsMatch)
    {
        if (isWildcard)
        {
            if (wildcardIsMatch is null)
            {
                throw new ArgumentNullException(nameof(wildcardIsMatch), "Wildcard match function is required when isWildcard is true");
            }

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (wildcardIsMatch(list[i], pattern))
                {
                    list.RemoveAt(i);
                }
            }
        }
        else
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (list[i].Contains(pattern))
                {
                    list.RemoveAt(i);
                }
            }
        }
    }
}
