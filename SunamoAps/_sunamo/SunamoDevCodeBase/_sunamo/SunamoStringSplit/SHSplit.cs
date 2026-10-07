namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class SHSplit
{
    /// <summary>
    /// Split.
    /// </summary>
    internal static List<string> Split(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    /// Split to parts.
    /// </summary>
    internal static List<string>? SplitToParts(string what, int parts, string delimiter)
    {
        var text = Split(what.RemoveInvisibleChars(), delimiter);
        if (text.Count < parts)
        {
            // Pokud je pocet ziskanych partu mensi, vlozim do zbytku prazdne retezce
            if (text.Count > 0)
            {
                var paddedResult = new List<string>();
                for (var index = 0; index < parts; index++)
                    if (index < text.Count)
                        paddedResult.Add(text[index]);
                    else
                        paddedResult.Add("");
                return paddedResult;
                //return new string[] { text[0] };
            }

            return null;
        }

        if (text.Count == parts)
            // Pokud pocet ziskanych partu souhlasim presne, vratim jak je
            return text;
        // Pokud je pocet ziskanych partu vetsi nez kolik ma byt, pripojim ty co josu navic do zbytku
        parts--;
        var result = new List<string>();
        for (var partIndex = 0; partIndex < text.Count; partIndex++)
            if (partIndex < parts)
                result.Add(text[partIndex]);
            else if (partIndex == parts)
                result.Add(text[partIndex] + delimiter);
            else if (partIndex != text.Count - 1)
                result[parts] += text[partIndex] + delimiter;
            else
                result[parts] += text[partIndex];
        return result;
    }

    /// <summary>
    /// Split char.
    /// </summary>
    internal static List<string> SplitChar(string text, char delimiter)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, text, (new List<char>([delimiter]).ConvertAll(character => character.ToString()).ToArray()));
    }

    /// <summary>
    /// Split.
    /// </summary>
    internal static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] delimiter)
    {
        if (delimiter == null || delimiter.Length == 0)
        {
            throw new Exception("NoDelimiterDetermined");
        }
        var result = text.Split(delimiter, stringSplitOptions).ToList();
        CA.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
        {
            result = result.Where(line => line.Trim() != string.Empty).ToList();
        }

        return result;
    }
}
