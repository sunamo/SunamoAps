namespace SunamoAps.Aps;

/// <summary>
/// Represents the all projects search consts type.
/// </summary>
public partial class AllProjectsSearchConsts
{
    /// <summary>
    /// The fn latest clear temp files constant.
    /// </summary>
    public const string FnLatestClearTempFiles = "LatestClearTempFiles";

    private List<string> foldersIgnore = new List<string> { "Addins", "Settings", "Templates", "Visualizers",
    "ArchitectureExplorer", "Backup Files",  "Code Snippets", "StartPages", "Assemblies", "Blend" };

    /// <summary>
    /// Gets or sets the ext code elements.
    /// </summary>
    public static List<string> ExtCodeElements { get; set; } = new List<string> { ".cs", ".ts", ".dart" };

    /// <summary>
    /// Gets or sets the ext files 2.
    /// </summary>
    public static List<string> ExtFiles2 { get; set; } = new List<string> { ".ashx", ".aspx", ".xaml", ".cshtml" };

    /// <summary>
    /// The for aps plugins constant.
    /// </summary>
    public const byte ForApsPlugins = 9;
}