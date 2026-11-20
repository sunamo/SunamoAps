namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the compile item group type.
/// </summary>
public class CompileItemGroup : ItemGroupElement
{
    /// <summary>
    /// The link.
    /// </summary>
    public string? Link = null;

    // Full path to the file - use in checking whether exists already, not for simple adding
    /// <summary>
    /// The full path file.
    /// </summary>
    public string? FullPathFile = null;

    // A1 - To csproj. Must exists. From it and relative structure is filled other properties
    /// <summary>
    /// Compile item group.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    /// <returns>The compile item group result.</returns>
    public CompileItemGroup(string fullPath) : base(fullPath)
    {
    }

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    /// <returns>The to xml result.</returns>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        throw new Exception("Make it with ");
    }
}