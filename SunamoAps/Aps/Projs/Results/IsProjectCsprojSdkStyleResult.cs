namespace SunamoAps.Aps.Projs.Results;

/// <summary>
/// Represents the is project csproj sdk style result type.
/// </summary>
public class IsProjectCsprojSdkStyleResult
{
    /// <summary>
    /// Gets or sets the is project csproj sdk style is core.
    /// </summary>
    public bool IsProjectCsprojSdkStyleIsCore { get; set; }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// Gets or sets the is netstandard.
    /// </summary>
    public bool IsNetstandard { get; set; }
}