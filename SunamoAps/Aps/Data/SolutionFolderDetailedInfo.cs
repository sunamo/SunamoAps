namespace SunamoAps.Aps.Data;

/// <summary>
/// Represents the solution folder detailed info type.
/// </summary>
public class SolutionFolderDetailedInfo : SolutionFolder
{
    // TODO: whole was moved to Aps.Statistic. use interface and to initialize delegate

    /// <summary>
    /// The overall files.
    /// </summary>
    public int OverallFiles = 0;

    /// <summary>
    /// Solution folder detailed info.
    /// </summary>
    /// <param name="solutionFolder">The solution folder.</param>
    /// <returns>The solution folder detailed info result.</returns>
    public SolutionFolderDetailedInfo(SolutionFolder solutionFolder)
    {
        CountOfImages = solutionFolder.CountOfImages;
        DisplayedText = solutionFolder.DisplayedText;
        FullPathFolder = solutionFolder.FullPathFolder;
        NameSolutionWithoutDiacritic = solutionFolder.NameSolutionWithoutDiacritic;

        DisplayedText += " (" + OverallFiles.ToString() + ")";
    }
}

internal class SolutionFolderDetailedInfoComparerBySourceFiles : IComparer<SolutionFolderDetailedInfo>
{
    public int Compare(SolutionFolderDetailedInfo? first, SolutionFolderDetailedInfo? second)
    {
        if (first == null || second == null) return 0;
        return first.OverallFiles.CompareTo(second.OverallFiles) * -1;
    }
}