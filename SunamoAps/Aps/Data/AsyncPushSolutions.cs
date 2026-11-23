namespace SunamoAps.Aps.Data;

/// <summary>
/// Represents the async push solutions type.
/// </summary>
public class AsyncPushSolutions : AsyncLoadingBaseDC<AsyncPushSolutions, IProgressBarDC>
{
    /// <summary>
    /// Gets or sets the folders with solutions.
    /// </summary>
    public List<SolutionFolder> FoldersWithSolutions { get; set; } = null!;
    /// <summary>
    /// Gets or sets the release.
    /// </summary>
    public bool Release { get; set; }
    /// <summary>
    /// Gets or sets the git bash builder.
    /// </summary>
    public GitBashBuilder GitBashBuilder { get; set; } = null!;
    /// <summary>
    /// Gets or sets the push args.
    /// </summary>
    public string PushArgs { get; set; } = null!;
    /// <summary>
    /// Gets or sets the commit message.
    /// </summary>
    public string? CommitMessage { get; set; }
    /// <summary>
    /// Gets or sets the push solutions data.
    /// </summary>
    public PushSolutionsData PushSolutionsData { get; set; } = null!;
    /// <summary>
    /// Gets or sets the git status.
    /// </summary>
    public GitBashBuilder GitStatus { get; set; } = null!;
}