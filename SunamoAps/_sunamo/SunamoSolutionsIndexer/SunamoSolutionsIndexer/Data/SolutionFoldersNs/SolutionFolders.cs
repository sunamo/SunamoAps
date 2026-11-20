namespace SunamoAps._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer.Data.SolutionFoldersNs;

/// <summary>
/// Represents the solution folders type.
/// </summary>
public class SolutionFolders : List<SolutionFolder>
{
    private Dictionary<string, SolutionFolder>? index = null;

    /// <summary>
    /// Initializes a new instance of SolutionFolders.
    /// </summary>
    public SolutionFolders(IList<SolutionFolder> collection) : base(collection)
    {
    }

    /// <summary>
    /// The this string.
    /// </summary>
    public SolutionFolder this[string solutionName]
    {
        get => index![solutionName];
    }
}