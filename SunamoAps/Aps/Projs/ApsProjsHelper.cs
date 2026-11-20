namespace SunamoAps.Aps.Projs;

/// <summary>
/// Represents the aps projs helper type.
/// </summary>
public class ApsProjsHelper
{
    /// <summary>
    /// The type.
    /// </summary>
    public static Type Type = typeof(ApsProjsHelper);

    /// <summary>
    /// Replace path with csproj.
    /// </summary>
    /// <param name="ApsProjsHelper">The aps projs helper.</param>
    /// <returns>The replace path with csproj result.</returns>
    public static void ReplacePathWithCsproj(ILogger logger, List<string> projectsToAdd)
    {
        for (int index = 0; index < projectsToAdd.Count; index++)
        {
            var item = projectsToAdd[index];
            var csproj = ApsHelper.Instance.GetCsprojsOnlyTopDirectory(logger, item);
            if (csproj.Count > 0)
            {
                projectsToAdd[index] = csproj[0];
            }
            else
            {
                projectsToAdd[index] = $"Folder {item} doesn't have csproj";
            }
        }
    }

    /// <summary>
    /// Absolute to relative cs proj.
    /// </summary>
    /// <param name="csprojPath">The csproj path.</param>
    /// <param name="basePath">The base path.</param>
    /// <returns>The absolute to relative cs proj result.</returns>
    public static
    async Task<XmlDocument>
         AbsoluteToRelativeCsProj(string csprojPath, string basePath)
    {
        if (csprojPath == null)
        {
            return null!;
        }
        var xmlDocumentResult =
            await
        XmlDocumentsCache.Get(csprojPath);
        if (MayExcHelper.MayExc(xmlDocumentResult.Exc))
        {
            return null!;
        }
        var projectReferences =
            await
        VsProjectsFileHelper.GetProjectReferences(csprojPath, null!, UriKind.RelativeOrAbsolute);
        // When file contains e.g. git characters, GetProjectReferencesAsync
        if (projectReferences.Projects != null)
        {
            if (projectReferences.Projects.Count != projectReferences.Nodes.Count)
            {
                ThrowEx.DifferentCountInLists("nodes", projectReferences.Nodes.Count, "projs", projectReferences.Projects.Count);
            }
            for (int index = 0; index < projectReferences.Nodes.Count; index++)
            {
                var projectPath = projectReferences.Projects[index];
                var isAbsolutePath = FS.IsAbsolutePath(projectPath);
                if (DefaultPaths.IsIgnored(projectPath, basePath))
                {
                    continue;
                }
                if (isAbsolutePath)
                {
                    var relativePath = PathPolyfill.GetRelativePath(csprojPath, projectPath);
                    var node = projectReferences.Nodes[index];
                    XmlNode clonedNode = node.Clone();
                    XmlHelper.SetAttribute(clonedNode, "Include", relativePath);
                    node.ParentNode!.ReplaceChild(clonedNode, node);
                }
            }
            await XmlDocumentsCache.Set(csprojPath, xmlDocumentResult.Data);
        }
        return xmlDocumentResult.Data;
    }
    #region Projs - working with projects absolutely independently of .sln existence
    /// <summary>
    /// Save empty test project.
    /// </summary>
    /// <param name="csprojPath">The csproj path.</param>
    public static
    async Task
 SaveEmptyTestProject(string csprojPath)
    {
        await
        TF.WriteAllText(csprojPath, "<Project Sdk=\"Microsoft.NET.Sdk\"></Project>");
    }

    /// <summary>
    /// Save empty full net project.
    /// </summary>
    /// <param name="csprojPath">The csproj path.</param>
    /// <param name="projectName">The project name.</param>
    /// <param name="projectsBasePath">The projects base path.</param>
    public static
    async Task
 SaveEmptyFullNetProject(string csprojPath, string projectName, string projectsBasePath)
    {
        var templateContent =
    await
 TF.ReadAllText(Path.Combine(projectsBasePath, @"SunamoDevCode\Templates\FullNet.xml"));
        string content = SHFormat.Format4(templateContent!, projectName);
        await
        TF.WriteAllText(csprojPath, content);
    }

    /// <summary>
    /// Remove schema.
    /// </summary>
    /// <param name="MSBuildProject"">The MS build project.</param>
    /// <returns>The remove schema result.</returns>
    [Obsolete("Used MSBuildProject")]
    public static string RemoveSchema(string content)
    {
        return content;
    }
    #endregion
    #region Uap
    /// <summary>
    /// Change uap framework.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="solutionFolder">The solution folder.</param>
    /// <param name="targetFramework">The target framework.</param>
    /// <param name="minFramework">The min framework.</param>
    /// <returns>The change uap framework result.</returns>
    public static void ChangeUapFramework(ILogger logger, SolutionFolder solutionFolder, string targetFramework, string minFramework)
    {
        SolutionFolder.GetCsprojs(logger, solutionFolder);
        foreach (var item in solutionFolder.ProjectsGetCsprojs)
        {
            VsProjectsFileHelper.SetTargetFrameworksUap(item, targetFramework, minFramework);
        }
    }
    #endregion
}