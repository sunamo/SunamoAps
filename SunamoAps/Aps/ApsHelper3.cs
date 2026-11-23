namespace SunamoAps.Aps;

public partial class ApsHelper : ApsPluginStatic
{
    /// <summary>
    /// Get files for git exclude temporary.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="folder">The folder.</param>
    /// <param name="typedExt">The typed ext.</param>
    /// <returns>The get files for git exclude temporary result.</returns>
    public List<string> GetFilesForGitExcludeTemporary(ILogger logger, string folder, string typedExt)
    {
        var files = FSGetFiles.GetFiles(logger, folder, FS.MascFromExtension(typedExt), SearchOption.AllDirectories);
        SunamoDevCodeHelper.RemoveTemporaryFilesVS(files);
        return files;
    }

    /// <summary>
    /// Full paths from solutions names.
    /// </summary>
    /// <param name="slnNames">The sln names.</param>
    /// <returns>The full paths from solutions names result.</returns>
    public static List<string> FullPathsFromSolutionsNames(List<KeyValuePair<string, string>> slnNames)
    {
        var result = new List<string>();
        foreach (var item in slnNames)
        {
            var sln = SolutionsIndexerHelper.SolutionWithName(item.Value);
            result.Add(sln!.FullPathFolder);
        }

        return result;
    }
}