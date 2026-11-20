namespace SunamoAps.Aps.Values;

/// <summary>
/// Represents the move to shared type.
/// </summary>
public class MoveToShared : IMoveToShared
{
    /// <summary>
    /// Gets or sets the folder.
    /// </summary>
    public string Folder { get; set; } = null!;

    /// <summary>
    /// Gets or sets the folder sunamo.
    /// </summary>
    public string FolderSunamo { get; set; } = null!;

    /// <summary>
    /// Gets or sets the folder sunamo web.
    /// </summary>
    public string FolderSunamoWeb { get; set; } = null!;

    /// <summary>
    /// Gets or sets the postfix.
    /// </summary>
    public string Postfix { get; set; } = "web";

    /// <summary>
    /// Gets or sets the sln from.
    /// </summary>
    public string SlnFrom { get; set; } = "sunamo";

    /// <summary>
    /// Initializes a new instance of the move to shared class.
    /// </summary>
    /// <param name="baseFolder">The base folder.</param>
    public MoveToShared(string baseFolder)
    {
        this.Folder = baseFolder;

        // Projects\\ must be here for sunamo.cz
        FolderSunamo = baseFolder + "Projects\\" + SlnFrom + "\\";
        FolderSunamoWeb = baseFolder + "Projects\\" + "sunamo." + Postfix + "\\";
    }
}