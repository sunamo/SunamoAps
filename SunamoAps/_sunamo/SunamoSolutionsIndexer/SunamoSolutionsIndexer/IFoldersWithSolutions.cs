namespace SunamoAps._sunamo.SunamoSolutionsIndexer;

public interface IFoldersWithSolutions
{
    /// <summary>
    /// Solutions.
    /// </summary>
    SolutionFolders Solutions(RepositoryLocal repository, bool isLoadingAll = true, IList<string>? skipThese = null, ProjectsTypes prioritize = ProjectsTypes.None);
}
