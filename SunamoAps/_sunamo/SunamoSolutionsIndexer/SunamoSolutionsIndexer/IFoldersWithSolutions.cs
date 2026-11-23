namespace SunamoAps._sunamo.SunamoSolutionsIndexer.SunamoSolutionsIndexer;

/// <summary>
/// Represents the i folders with solutions type.
/// </summary>
public interface IFoldersWithSolutions
{
    /// <summary>
    /// Solutions.
    /// </summary>
    SolutionFolders Solutions(RepositoryLocal repository, bool isLoadingAll = true, IList<string>? skipThese = null, ProjectsTypes prioritize = ProjectsTypes.None);
}