namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class AppPaths
{
    /// <summary>
    /// Get startup path.
    /// </summary>
    internal static string GetStartupPath()
    {
        return Path.GetDirectoryName(Process.GetCurrentProcess().MainModule!.FileName)!;
    }

    /// <summary>
    /// Get file in startup path.
    /// </summary>
    internal static string GetFileInStartupPath(string fileName)
    {
        return Path.Combine(GetStartupPath(), fileName);
    }
}
