namespace SunamoAps.Aps.Projs.Data;

/// <summary>
/// Represents the project references type.
/// </summary>
public class ProjectReferences
{
    /// <summary>
    /// Gets or sets the projects.
    /// </summary>
    public List<string> Projects { get; set; } = null!;

    /// <summary>
    /// Gets or sets the nodes.
    /// </summary>
    public List<XmlNode> Nodes { get; set; } = null!;
}