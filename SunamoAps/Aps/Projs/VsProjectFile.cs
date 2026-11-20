namespace SunamoAps.Aps.Projs;

// In case when ProjectCollection wont work (like actually dont return any Compile elements)
/// <summary>
/// Represents the vs project file type.
/// </summary>
public class VsProjectFile
{
    /// <summary>
    /// The file.
    /// </summary>
    public string file = null!;
    XmlDocument? xDocument = null;
    XmlNamespacesHolder? holder = null;
    /// <summary>
    /// The is core.
    /// </summary>
    public bool IsCore
    {
        get; set;
    }
    XmlNamespaceManager? nsmgr
    {
        get
        {
            return holder?.NamespaceManager!;
        }
    }
    /// <summary>
    /// Gets the name.
    /// </summary>
    public string Name => Path.GetFileNameWithoutExtension(file);
    /// <summary>
    /// Load.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="dictToAvoidCollectionWasChanged">The dict to avoid collection was changed.</param>
    public
    async Task
        Load(string file, Dictionary<string, XmlDocument>? dictToAvoidCollectionWasChanged)
    {
        this.file = file;
        if (dictToAvoidCollectionWasChanged == null)
        {
            var result =
                await
                XmlDocumentsCache.Get(file);
            if (MayExcHelper.MayExc(result.Exc))
            {
                return;
            }
            xDocument = result.Data;
        }
        else
        {
            xDocument = dictToAvoidCollectionWasChanged.ContainsKey(file)
                ? dictToAvoidCollectionWasChanged[file]
                : null;
        }
    }
    /// <summary>
    /// Vs project file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns>The vs project file result.</returns>
    public VsProjectFile()
    {
    }
    // Before calling must check whether file is exists
    /// <summary>
    /// Vs project file.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <returns>The vs project file result.</returns>
    public VsProjectFile(string file)
    {
        // async ctor is not possible. that is why I can never load this in the ctor again
        // from now on I will use only .net core forever
        Load(file, null).RunSynchronously();
    }
    /// <summary>
    /// Gets the is valid xml.
    /// </summary>
    public bool IsValidXml => xDocument != null;
    #region TODO: working with XmlDocument which is not supported already
    #endregion

    /// <summary>
    /// Get element of name.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="null">The null.</param>
    /// <returns>The get element of name result.</returns>
    public static XmlNode GetElementOfName(XmlNode element, string name)
    {
        return element.ChildNodes.First(name);
    }
    /// <summary>
    /// Return all item group.
    /// </summary>
    /// <param name="element">The element.</param>
    /// <param name="name">The name.</param>
    /// <returns>The return all item group result.</returns>
    public List<XmlNode> ReturnAllItemGroup(ItemGroups itemGroup)
    {
        var project = XmlHelper.GetElementOfName(xDocument!, "Project")!;
        var itemGroups = XmlHelper.GetElementsOfName(project!, "ItemGroup");
        var xelements = new List<XmlNode>();
        foreach (var item in itemGroups)
        {
            xelements.AddRange(XmlHelper.GetElementsOfName(item, itemGroup.ToString()));
        }
        return xelements;
    }
    /// <summary>
    /// Delete.
    /// </summary>
    /// <param name="itemGroup">The item group.</param>
    /// <returns>The delete result.</returns>
    public void Delete(List<XmlElement> compile)
    {
        foreach (var item in compile)
        {
            item.ParentNode?.RemoveChild(item);
        }
    }
    /// <summary>
    /// Save.
    /// </summary>
    /// <param name="itemGroup.ToString())">The item group to string.</param>
    /// <returns>The save result.</returns>
    public void Save()
    {
        xDocument!.Save(file);
    }
}