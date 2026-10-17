namespace SunamoAps._sunamo.SunamoDevCodeBase._sunamo;

internal class DefaultPaths
{
    /// <summary>
    /// Is ignored.
    /// </summary>
    internal static bool IsIgnored(string path, string bpBb) => path.StartsWith(bpBb);
}