namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the content item group type.
/// </summary>
public class ContentItemGroup : ItemGroupElement
{
    /// <summary>
    /// Initializes a new instance of the content item group class.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    public ContentItemGroup(string fullPath) : base(fullPath)
    {
    }

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="xmlDocument">The xml document.</param>
    /// <returns>The to xml result.</returns>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        return null!;
    }
}