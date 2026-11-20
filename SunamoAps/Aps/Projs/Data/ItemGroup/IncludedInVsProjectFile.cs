namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the included in vs project file type.
/// </summary>
public class IncludedInVsProjectFile
{
    /// <summary>
    /// Gets or sets the compile.
    /// </summary>
    public List<CompileItemGroup> Compile { get; set; } = new List<CompileItemGroup>();
}