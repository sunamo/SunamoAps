namespace SunamoAps._sunamo.SunamoSolutionsIndexer;

public class SolutionFolders : List<SolutionFolder>
{
    private Dictionary<string, SolutionFolder>? index = null;

    /// <summary>
    /// Initializes a new instance of SolutionFolders.
    /// </summary>
    public SolutionFolders(IList<SolutionFolder> collection) : base(collection)
    {
    }

    public SolutionFolder this[string solutionName]
    {
        get => index![solutionName];
    }
}