namespace SunamoAps.Aps;

/// <summary>
/// Represents the all projects search throw type.
/// </summary>
public class AllProjectsSearchThrow
{
    /// <summary>
    /// Is not valid project file.
    /// </summary>
    /// <param name="filePath">The file path.</param>
    public static void IsNotValidProjectFile(string filePath)
    {
        ThrowEx.Custom(filePath + " is not valid project file.");
    }
}