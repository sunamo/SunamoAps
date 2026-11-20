namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the project reference item group type.
/// </summary>
public class ProjectReferenceItemGroup : ItemGroupElement
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type Type = typeof(ProjectReferenceItemGroup);

    /// <summary>
    /// Gets or sets the project.
    /// </summary>
    public string? Project { get; set; } = null;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string? Name { get; set; } = null;

    /// <summary>
    /// Project reference item group.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    /// <returns>The project reference item group result.</returns>
    public ProjectReferenceItemGroup(string fullPath) : base(fullPath)
    {
    }

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    /// <returns>The to xml result.</returns>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        // .NET Framework also adds Name and ProjectGuid elements, but they are not required and it works the same without them. Tested with rebuild.
        var xmlContent = "<" + ItemGroups.ProjectReference + " Include=\"" + Include + "\" />";
        XmlNode node = XH.ReturnXmlNode(xmlContent.ToString());
        return node;
    }
}