namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the item group element type.
/// </summary>
public abstract class ItemGroupElement
{
    /// <summary>
    /// Initializes a new instance of the item group element class.
    /// </summary>
    /// <param name="fullPath">The full path.</param>
    public ItemGroupElement(string fullPath)
    {
        this.FullPath = fullPath;
    }

    // Must exist. From it and relative structure, other properties are filled.
    /// <summary>
    /// Gets or sets the full path.
    /// </summary>
    public string FullPath { get; set; }

    /// <summary>
    /// Gets or sets the include.
    /// </summary>
    public string Include { get; set; } = null!;

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="xmlDocument">The xml document.</param>
    /// <returns>The to xml result.</returns>
    public abstract XmlNode ToXml(XmlDocument xmlDocument);
}