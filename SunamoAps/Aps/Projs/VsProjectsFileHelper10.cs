namespace SunamoAps.Aps.Projs;

// Use VsProjectFile,
public partial class VsProjectsFileHelper
{
    /// <summary>
    /// Get tokens.
    /// </summary>
    /// <param name="relativePath">The relative path.</param>
    /// <returns>The get tokens result.</returns>
    public static List<string> GetTokens(string relativePath)
    {
        var deli = "";
        if (relativePath.Contains("\""))
            deli = "\"";
        else if (relativePath.Contains("/")) deli = "/";
        else
        {
            ThrowEx.NotImplementedCase(relativePath);
        }
        return SHSplit.Split(relativePath, deli);
    }
    #region Use cacheProjectReferences
    /// <summary>
    /// The cache project references.
    /// </summary>
    public static Dictionary<string, ProjectReferences> cacheProjectReferences = new Dictionary<string, ProjectReferences>();
    /// <summary>
    /// Get project references.
    /// </summary>
    /// <param name="csprojPath">The csproj path.</param>
    /// <param name="dictToAvoidCollectionWasChanged">The dict to avoid collection was changed.</param>
    /// <param name="uriKind">The uri kind.</param>
    /// <returns>The get project references result.</returns>
    public static
        async Task<ProjectReferences>
        GetProjectReferences(string csprojPath, Dictionary<string, XmlDocument> dictToAvoidCollectionWasChanged, UriKind uriKind = UriKind.Absolute)
    {
        // Not
        csprojPath = SH.FirstCharUpper(csprojPath);
        if (cacheProjectReferences.ContainsKey(csprojPath))
        {
            return cacheProjectReferences[csprojPath];
        }
        if (!FS.ExistsFile(csprojPath))
        {
            return new ProjectReferences();
        }
        var projectFile = new VsProjectFile();
        await
        projectFile.Load(csprojPath, dictToAvoidCollectionWasChanged);
        if (!projectFile.IsValidXml)
        {
            return new ProjectReferences();
        }
        var nodes = projectFile.ReturnAllItemGroup(ItemGroups.ProjectReference);
        var projectReferences = nodes.Select(node => XmlHelper.Attr(node, "Include")!).ToList();
        var directoryName = FS.GetDirectoryName(csprojPath);
        if (uriKind == UriKind.Absolute)
        {
            CAChangeContent.ChangeContent(new ChangeContentArgsDC { }, projectReferences, FS.GetAbsolutePath2, directoryName);
        }
        else if (uriKind == UriKind.Relative)
        {
            CAChangeContent.ChangeContent(new ChangeContentArgsDC { SwitchFirstAndSecondArg = true }, projectReferences, null!, directoryName, PathPolyfill.GetRelativePath);
        }
        var projectReferencesResult = new ProjectReferences { Projects = projectReferences, Nodes = nodes };
        if (!cacheProjectReferences.ContainsKey(csprojPath))
        {
            cacheProjectReferences.Add(csprojPath, projectReferencesResult);
        }
        return projectReferencesResult;
    }
    #endregion
    /// <summary>
    /// Add files to csproj.
    /// </summary>
    /// <param name="sln">The sln.</param>
    /// <param name="csprojpath">The csprojpath.</param>
    /// <param name="files">The files.</param>
    /// <returns>The add files to csproj result.</returns>
    public static async Task AddFilesToCsproj(SolutionFolder sln, string csprojpath, List<string> files)
    {
        var containedFiles = new List<string>();
        var dir = FS.GetDirectoryName(csprojpath);
        var projectFile = new VsProjectFile(csprojpath);
        if (!projectFile.IsValidXml)
        {
            return;
        }
        var compile = projectFile.ReturnAllItemGroup(ItemGroups.Compile).Select(node => XmlHelper.Attr(node, "Include")!);
        foreach (var item in compile)
        {
            containedFiles.Add(FS.GetAbsolutePath(dir, item!));
        }
        foreach (var item in files)
        {
            if (!containedFiles.Contains(item))
            {
                var compileItemGroup = new CompileItemGroup(csprojpath);
                var relativePathFromSolution = ApsHelper.Instance.GetRelativePathFromSolution(sln, item);
                var tokens = FS.GetTokens(relativePathFromSolution);
                tokens.RemoveAt(0);
                tokens.RemoveAt(0);
                compileItemGroup.Include = Path.Combine(tokens.ToArray());
                await AddItemGroupSdkStyle(csprojpath, ItemGroups.Compile, compileItemGroup, true);
            }
        }
    }
}