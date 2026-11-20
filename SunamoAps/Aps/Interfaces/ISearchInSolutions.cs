namespace SunamoAps.Aps.Interfaces;

/// <summary>
/// Represents the i search in solutions type.
/// </summary>
public interface ISearchInSolutions
{
    /// <summary>
    /// Add to latest.
    /// </summary>
    /// <param name="solutionFolderSerialize">The solution folder serialize.</param>
    void AddToLatest(SolutionFolderSerialize solutionFolderSerialize);
}