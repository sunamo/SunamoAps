namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class TF
{
    /// <summary>
    /// Read all lines.
    /// </summary>
    internal static async Task<List<string>?> ReadAllLines(string filePath)
    {
        return (await FileAsync.ReadAllLinesAsync(filePath)).ToList();
    }

    /// <summary>
    /// Read all text.
    /// </summary>
    internal static async Task<string?> ReadAllText(string filePath)
    {
        return await FileAsync.ReadAllTextAsync(filePath);
    }

    /// <summary>
    /// Write all text.
    /// </summary>
    internal static async Task WriteAllText(string filePath, string content)
    {
        await FileAsync.WriteAllTextAsync(filePath, content);
    }
}
