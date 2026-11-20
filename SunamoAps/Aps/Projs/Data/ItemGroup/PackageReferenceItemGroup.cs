namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the package reference item group type.
/// </summary>
public class PackageReferenceItemGroup : ItemGroupElement
{
    /// <summary>
    /// Gets or sets the version.
    /// </summary>
    public string? Version { get; set; } = null;

    /// <summary>
    /// The type.
    /// </summary>
    public static Type Type = typeof(PackageReferenceItemGroup);

    /// <summary>
    /// Package reference item group.
    /// </summary>
    /// <param name="PackageReferenceItemGroup">The package reference item group.</param>
    /// <returns>The package reference item group result.</returns>
    public PackageReferenceItemGroup(string fullCsprojPath) : base(fullCsprojPath)
    {
    }

    /// <summary>
    /// Package reference item group.
    /// </summary>
    /// <param name="PackageReferenceItemGroup">The package reference item group.</param>
    /// <returns>The package reference item group result.</returns>
    public PackageReferenceItemGroup(string fullCsprojPath, XmlNode xmlElement) : base(fullCsprojPath)
    {
        const string VersionAttributeName = "Version";
        Include = XmlHelper.Attr(xmlElement, "Include")!;
        Version = XmlHelper.InnerTextOfNode(xmlElement);
        if (Version == string.Empty)
        {
            Version = XmlHelper.Attr(xmlElement, VersionAttributeName)!;
        }
    }

    /// <summary>
    /// Initializes a new instance of the to xml class.
    /// </summary>
    /// <param name="Version">The version.</param>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        return null!;
    }
}