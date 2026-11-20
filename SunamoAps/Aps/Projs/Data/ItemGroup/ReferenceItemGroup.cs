namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the reference item group type.
/// </summary>
public class ReferenceItemGroup : ItemGroupElement
{
    /// <summary>
    /// The type.
    /// </summary>
    public static readonly Type Type = typeof(ReferenceItemGroup);

    /// <summary>
    /// Gets or sets the include parts.
    /// </summary>
    public Dictionary<string, string> IncludeParts { get; set; } = new Dictionary<string, string>();

    // Relative path from project folder to DLL used as HintPath.
    // Used later in AddItemGroup2 as HintPath.
    private string? relativePathDllToProjectFolderHintPath = null;

    /// <summary>
    /// Reference item group.
    /// </summary>
    /// <returns>The reference item group result.</returns>
    public ReferenceItemGroup(string fullPathDllInclude, string fullPathCsproj, string relativePathDllToProjectFolderHintPath) : base(fullPathCsproj)
    {
        Include = fullPathDllInclude;
        this.relativePathDllToProjectFolderHintPath = relativePathDllToProjectFolderHintPath;
    }

    /// <summary>
    /// Initializes a new instance of the reference item group class.
    /// </summary>
    /// <param name="fullPathDllInclude">The full path dll include.</param>
    /// <param name="fullPathCsproj">The full path csproj.</param>
    /// <param name="relativePathDllToProjectFolderHintPath">The relative path dll to project folder hint path.</param>
    public ReferenceItemGroup(string fullPathCsproj, XmlNode xmlElement) : base(fullPathCsproj)
    {
        Include = XmlHelper.Attr(xmlElement, "Include")!;
        if (Include!.Contains(","))
        {
            var includeParts = SHSplit.Split(Include, ",");
            CA.Trim(includeParts);
            foreach (var item in includeParts)
            {
                if (item.Contains("="))
                {
                    var parts = SHSplit.Split(item, "=");
                    IncludeParts.Add(parts[0], parts[1]);
                }
            }
        }
    }

    /// <summary>
    /// Gets the version.
    /// </summary>
    public string Version => FromInclude("Version");

    private string FromInclude(string key)
    {
        if (IncludeParts.ContainsKey(key))
        {
            return IncludeParts[key];
        }
        return string.Empty;
    }

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <returns>The to xml result.</returns>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        var generator = new XmlGenerator();
        generator.WriteTagWithAttrsCheckNull(VsProjectItemTypes.Reference, "Include", Include);
        generator.TerminateTag(VsProjectItemTypes.Reference);
        XmlNode node = XH.ReturnXmlNode(generator.ToString()!);
        return node;
    }
}