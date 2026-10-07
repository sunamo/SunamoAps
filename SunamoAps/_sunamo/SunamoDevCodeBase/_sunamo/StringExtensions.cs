namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal static class StringExtensions
{
    /// <summary>
    /// Remove invisible chars.
    /// </summary>
    internal static string RemoveInvisibleChars(this string input)
    {
        int[] charsToRemove = [8205];
        return new string(input.ToCharArray()
            .Where(character => !charsToRemove.Contains(character))
            .ToArray());
    }
}