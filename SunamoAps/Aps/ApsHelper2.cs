namespace SunamoAps.Aps;

public partial class ApsHelper : ApsPluginStatic
{
    /// <summary>
    /// Enter output of powershell git change dialog result.
    /// </summary>
    /// <param name="shouldProcessMessages">The should process messages.</param>
    /// <param name="stringBuilder">The string builder.</param>
    /// <param name="eVs">The e vs.</param>
    /// <param name="pathGetMessagesFromGitOutput">The path get messages from git output.</param>
    public
    async Task
    EnterOutputOfPowershellGit_ChangeDialogResult(bool? shouldProcessMessages, GitBashBuilder stringBuilder, string eVs, string pathGetMessagesFromGitOutput)
    {
        var messages = (
    await
        GetMessagesFromGitOutput(shouldProcessMessages, pathGetMessagesFromGitOutput, eVs)).ToList();
        CA.Prepend("#", messages);
        var mess = new StringBuilder();
        if (messages.Count() == 0)
        {
            mess.AppendLine("#no errors");
        }
        else
        {
            foreach (var item in messages)
            {
                mess.AppendLine(item);
            }
        }

        var gitBashCommands = string.Empty;
        if (stringBuilder != null)
        {
            gitBashCommands = stringBuilder.ToString();
        }

        if (pushSolutionsData.onlyThese != VpsHelperDevCode.ListVpsNew)
        {
            string vpsPath = eVs;
            var list = SHGetLines.GetLines(gitBashCommands);
            CA.Trim(list);
            for (int index = 0; index < list.Count; index++)
            {
                var line = list[index];
                if (line.StartsWith("cd "))
                {
                    var parts = SHSplit.Split(line, vpsPath);
                    var pathParts = SHSplit.SplitChar(parts[1], '\\');
                    var slnName = pathParts[0].TrimEnd('"');
                    var sfo = SolutionsIndexerHelper.SolutionWithName(slnName);
                    var directoryName = FS.GetDirectoryName(sfo!.FullPathFolder);
                    list[index] = list[index].Replace(vpsPath, directoryName);
                }
            }

            // Exists FS.WithEndSlash but there could be better
            gitBashCommands = SHJoin.JoinNL(list);
        }

        mess.AppendLine(gitBashCommands);
        ClipboardService.SetText(mess.ToString());
        if (!cmd)
        {
            MoveToApsWpf();
        }
        else
        {
            ThisApp.Success("Result was copied to clipboard");
        }

        // In next pushSolutionsData.onlyThese dont use so set it null to not forget to it
        pushSolutionsData.onlyThese = null!;
    }

    static void MoveToApsWpf()
    {
        ThrowEx.Custom("Move to Aps.wpf");
    }

    /// <summary>
    /// Skip these git.
    /// </summary>
    /// <returns>The skip these git result.</returns>
    public List<string> SkipTheseGit()
    {
        var skipThese = CA.ToListString("mono-server-setup");
        skipThese.Add(".vscode");
        return skipThese;
    }

    /// <summary>
    /// All solutions.
    /// </summary>
    /// <param name="vs17">The vs 17.</param>
    /// <returns>The all solutions result.</returns>
    public List<SolutionFolder> AllSolutions(RepositoryLocal vs17)
    {
        var data = new List<SolutionFolder>();
        foreach (var item in ApsMainWindow.Instance.Fwss)
        {
            var sln = item.GetSolutions(vs17);
            data.AddRange(sln);
        }

        return data;
    }

    // Repository type currently used by this ApsHelper instance.
    /// <summary>
    /// The repository used in aps h.
    /// </summary>
    public RepositoryLocal repositoryUsedInApsH = RepositoryLocal.Vs17;

    /// <summary>
    /// Is web project.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="sln">The sln.</param>
    /// <param name="getFileSettings">The get file settings.</param>
    /// <returns>The is web project result.</returns>
    public async Task<bool> IsWebProject(ILogger logger, SolutionFolder sln, GetFileSettings getFileSettings)
    {
        var webProjectsWildcard = await AllProjectsSearchSettings.GetWebProjectsWildCard(logger, getFileSettings);
        if (webProjectsWildcard.Count == 0)
        {
            ThrowEx.IsEmpty(webProjectsWildcard, "webProjectsWildcard", "For all elements will return false");
        }

        foreach (var item in webProjectsWildcard)
        {
            if (item.Value.IsMatch(sln.NameSolution))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Main sln 2.
    /// </summary>
    /// <param name="fullPathFolder">The full path folder.</param>
    /// <returns>The main sln 2 result.</returns>
    public string? MainSln2(string fullPathFolder)
    {
        var baseName = Path.Combine(fullPathFolder, FS.GetFileName(fullPathFolder));
        foreach (var ext in AllExtensions.AllSlnExtensions)
        {
            var slnPath = baseName + ext;
            if (FS.ExistsFile(slnPath))
            {
                return slnPath;
            }
        }
        return null;
    }

    /// <summary>
    /// Main sln.
    /// </summary>
    /// <param name="sln">The sln.</param>
    /// <returns>The main sln result.</returns>
    public string? MainSln(SolutionFolder sln)
    {
        string fullPathFolder = sln.FullPathFolder;
        string baseName;
        if (sln.SlnNameWithoutExtension == null)
        {
            baseName = Path.Combine(fullPathFolder, FS.GetFileName(fullPathFolder));
        }
        else
        {
            baseName = Path.Combine(fullPathFolder, sln.SlnNameWithoutExtension);
        }

        if (baseName.Contains("apps.sunamo.cz"))
        {
        }

        foreach (var ext in AllExtensions.AllSlnExtensions)
        {
            var slnPath = baseName + ext;
            if (FS.ExistsFile(slnPath))
            {
                return slnPath;
            }
        }
        return null;
    }

    /// <summary>
    /// Absolute path of project.
    /// </summary>
    /// <param name="project">The project.</param>
    /// <param name="slnName">The sln name.</param>
    /// <param name="eVsProjects">The e vs projects.</param>
    /// <returns>The absolute path of project result.</returns>
    public string AbsolutePathOfProject(string project, string slnName, string eVsProjects)
    {
        var path = Path.Combine(eVsProjects, slnName, project, project + ".csproj");
        return path;
    }

    /// <summary>
    /// Sln file path from folder.
    /// </summary>
    /// <param name="fullPathFolder">The full path folder.</param>
    /// <returns>The sln file path from folder result.</returns>
    public string SlnFilePathFromFolder(string fullPathFolder)
    {
        var folderName = FS.GetFileName(fullPathFolder);
        foreach (var ext in AllExtensions.AllSlnExtensions)
        {
            var path = Path.Combine(fullPathFolder, folderName + ext);
            if (FS.ExistsFile(path)) return path;
        }
        return Path.Combine(fullPathFolder, folderName + AllExtensions.SlnExtension);
    }

    // Save to A1 variables projectFolder and slnFullPath
    // A2 can be null, then will be detected automatically
    /// <summary>
    /// Get project folder and sln path.
    /// </summary>
    /// <param name="sln">The sln.</param>
    /// <param name="documentsFolder">The documents folder.</param>
    /// <returns>The get project folder and sln path result.</returns>
    public void GetProjectFolderAndSlnPath(SolutionFolder sln, string? documentsFolder = null)
    {
        if (documentsFolder == null)
        {
            documentsFolder = Instance.DetectDocumentsFolder(sln);
        }

        string relativeFromProjectFolder = sln.FullPathFolder.Substring(documentsFolder!.Length);
        var arr = SHSplit.SplitToParts(relativeFromProjectFolder, 3, "\\");
        // 0 - VS folder
        sln.projectFolder = arr![1];
        sln.slnFullPath = arr![2];
    }

    // Return without ../
    // Get relative path to A2 without solution base folder
    //
    /// <summary>
    /// Get relative path from solution.
    /// </summary>
    /// <param name="sln">The sln.</param>
    /// <param name="fullPathCsproj">The full path csproj.</param>
    /// <returns>The get relative path from solution result.</returns>
    public string GetRelativePathFromSolution(SolutionFolder sln, string fullPathCsproj)
    {
        GetProjectFolderAndSlnPath(sln, Instance.DetectDocumentsFolder(sln));
        var projectFolder = SH.WrapWith(sln.projectFolder, "\\");
        int projectFolderIndex = fullPathCsproj.IndexOf(projectFolder);
        string result = fullPathCsproj.Substring(projectFolderIndex + projectFolder.Length);
        // 25-1-20 added ..\ before
        result = "..\\" + result;
        return result;
    }

    // A2 - must be full paths to projects
    /// <summary>
    /// Add projects to sln.
    /// </summary>
    /// <param name="addProjectReferencesWhenAlreadyIsInSln">The add project references when already is in sln.</param>
    /// <param name="projectsToAdd">The projects to add.</param>
    /// <param name="slnFromWhichIsAdded">The sln from which is added.</param>
    /// <param name="projectTypes">The project types.</param>
    /// <param name="projectIds">The project ids.</param>
    /// <param name="slnToWhichAdd">The sln to which add.</param>
    /// <returns>The add projects to sln result.</returns>
    public async Task AddProjectsToSln(bool addProjectReferencesWhenAlreadyIsInSln, List<string> projectsToAdd, object slnFromWhichIsAdded, Dictionary<string, Guid> projectTypes, Dictionary<string, Guid> projectIds, string slnToWhichAdd)
    {
        // with dotnet cmd
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get csprojs only top directory.
    /// </summary>
    /// <returns>The get csprojs only top directory result.</returns>
    public List<string> GetCsprojsOnlyTopDirectory(ILogger logger, string projectPath)
    {
        var data = FSGetFiles.GetFiles(logger, projectPath, "*.csproj", SearchOption.TopDirectoryOnly);
        return data;
    }

    /// <summary>
    /// Get slns.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="path">The path.</param>
    /// <param name="getFilesArgs">The get files args.</param>
    /// <returns>The get slns result.</returns>
    public List<string> GetSlns(ILogger logger, string path, GetFilesArgsDC? getFilesArgs = null)
    {
        if (getFilesArgs == null)
        {
            getFilesArgs = new GetFilesArgsDC();
        }

        var slns = new List<string>();
        foreach (var ext in new[] { "*.sln", "*.slnx", "*.slnj" })
        {
            slns.AddRange(FSGetFiles.GetFiles(logger, path, ext, SearchOption.TopDirectoryOnly, getFilesArgs));
        }
        return slns;
    }

    /// <summary>
    /// Detect documents folder.
    /// </summary>
    /// <param name="sln">The sln.</param>
    /// <returns>The detect documents folder result.</returns>
    public string? DetectDocumentsFolder(SolutionFolder sln)
    {
        foreach (var item in ApsMainWindow.Instance.Fwss)
        {
            if (sln.FullPathFolder.Contains(item.DocumentsFolder))
            {
                return item.DocumentsFolder;
            }
        }

        return null;
    }

    /// <summary>
    /// Get relative path to project.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="slnFullPath">The sln full path.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The get relative path to project result.</returns>
    public string GetRelativePathToProject(string file, string slnFullPath, char delimiter)
    {
        int separatorCount = SH.OccurencesOfStringIn(slnFullPath, "/");
        if (separatorCount == 0)
        {
            separatorCount = SH.OccurencesOfStringIn(slnFullPath, "\\");
        }

        separatorCount += 2;
        string relativePath = FS.AddUpfoldersToRelativePath(separatorCount, file, delimiter);
        return relativePath;
    }
}