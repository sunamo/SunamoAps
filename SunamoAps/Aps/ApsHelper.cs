namespace SunamoAps.Aps;

/// <summary>
/// Represents the aps helper type.
/// </summary>
public partial class ApsHelper : ApsPluginStatic
{
    /// <summary>
    /// The instance.
    /// </summary>
    public static ApsHelper Instance = new ApsHelper();
    // Never create new instance, just call method
    /// <summary>
    /// The push solutions data.
    /// </summary>
    public PushSolutionsData pushSolutionsData = new PushSolutionsData();
    string? typed = null;
    bool cmd = false;
    GitBashBuilder gitPullVps = new GitBashBuilder(new TextBuilderDC());
    GitBashBuilder gitPushVps = new GitBashBuilder(new TextBuilderDC());
    // Separates all projects into web and non-web categories. Do not use XmlDocumentsCache.
    /// <summary>
    /// Web and non web projects.
    /// </summary>
    /// <returns>The web and non web projects result.</returns>
    public static Tuple<List<string>, List<string>> WebAndNonWebProjects(ILogger logger, bool withCsprojs = true)
    {
        List<string> webProjects = new List<string>();
        List<string> notWebProjects = new List<string>();
        foreach (var item in FoldersWithSolutions.Fwss)
        {
            var solutions = item.GetSolutions(RepositoryLocal.Vs17);
            foreach (var sln in solutions)
            {
                SolutionFolder.GetCsprojs(logger, sln);
                foreach (var projectPath in sln.ProjectsGetCsprojs)
                {
                    var finalProjectPath = withCsprojs ? projectPath : FS.GetDirectoryName(projectPath);
                    if (IsWeb(projectPath))
                    {
                        webProjects.Add(finalProjectPath);
                    }
                    else
                    {
                        notWebProjects.Add(finalProjectPath);
                    }
                }
            }
        }
        return new Tuple<List<string>, List<string>>(webProjects, notWebProjects);
    }

    /// <summary>
    /// Is web.
    /// </summary>
    /// <param name="webProjects">The web projects.</param>
    /// <param name="notWebProjects">The not web projects.</param>
    /// <returns>The is web result.</returns>
    public static bool IsWeb(string projectPath)
    {
        return CA.ContainsAnyFromElementBool(projectPath, AllProjectsSearchSettings.DontReplaceReferencesIn!);
    }

    /// <summary>
    /// Push solutions continuously window change dialog result.
    /// </summary>
    /// <param name="projectPath">The project path.</param>
    /// <returns>The push solutions continuously window change dialog result result.</returns>
    public async Task PushSolutionsContinuouslyWindow_ChangeDialogResult(bool? builder, Func<List<string>, Task<List<List<string>>>> psInvoke, string eVs, string pathGetMessagesFromGitOutput)
    {
        ThisApp.Appeal("PushSolutionsContinuouslyWindow_ChangeDialogResult");
        bool release = true;
        gitPullVps.Clear();
        GitBashBuilder gitBashBuilder = new GitBashBuilder(new TextBuilderDC());
        if (BTS.GetValueOfNullable(builder))
        {
            string pushArgs = "";
            // instead of this add print errors. with force I can lose my data
            string? commitMessage = null;
            if (cmd)
            {
                commitMessage = typed;
            }
            else
            {
                MoveToApsWpf();
            }

            GitBashBuilder gitStatus = new GitBashBuilder(new TextBuilderDC());
            bool push = true;
            List<SolutionFolder> foldersWithSolutions = new List<SolutionFolder>();
            var skipTheseGit = Instance.SkipTheseGit();
            if (pushSolutionsData.onlyThese != null)
            {
                ThisApp.Appeal("pushSolutionsData.onlyThese " + pushSolutionsData.onlyThese.Count);
            }
            else
            {
                ThisApp.Appeal("pushSolutionsData.onlyThese is null");
            }

            if (skipTheseGit != null)
            {
                ThisApp.Appeal("pushSolutionsData.onlyThese " + skipTheseGit.Count);
            }
            else
            {
                ThisApp.Appeal("pushSolutionsData.onlyThese is null");
            }

            bool isCs = pushSolutionsData.cs.HasValue;
            foreach (var item in Fwss)
            {
                // Its only push, no delete or change file so A2 can be true here
                var slns = item.GetSolutions(UsedRepository, true, skipTheseGit);
                foreach (var sln in slns)
                {
                    if (isCs)
                    {
#region MyRegion
#endregion
                    }

                    // Include also github, solutions which isnt mine return 403
                    push = true;
                    if (pushSolutionsData.onlyThese != null)
                    {
                        if (!pushSolutionsData.onlyThese.Contains(sln.NameSolution))
                        {
                            push = false;
                        }
                    }

                    if (push)
                    {
                        foldersWithSolutions.Add(sln);
                    }
                    else
                    {
                    }
                }
            }

            AsyncPushSolutions asyncPushSolutions = new AsyncPushSolutions
            {
                FoldersWithSolutions = foldersWithSolutions,
                Release = release,
                GitBashBuilder = gitBashBuilder,
                PushArgs = pushArgs,
                CommitMessage = commitMessage,
                PushSolutionsData = pushSolutionsData,
                GitStatus = gitStatus
            };
            if (cmd)
            {
                await
                CheckForPushInThread(asyncPushSolutions, psInvoke, eVs, pathGetMessagesFromGitOutput);
            }
            else
            {
                MoveToApsWpf();
#region New
            //                await
            //#endif
#endregion
#region Old
#endregion
            }
        }
        else
        {
            MoveToApsWpf();
        }

        ThisApp.Appeal("PushSolutionsContinuouslyWindow_ChangeDialogResult end");
    }

    /// <summary>
    /// Initializes a new instance of the all projects class.
    /// </summary>
    public List<string>? AllProjects(ILogger logger, RepositoryLocal vs17, WebNonWeb webNonWeb, bool withCsprojs = true)
    {
        if (vs17 != RepositoryLocal.Vs17)
        {
            ThrowEx.NotImplementedCase(vs17);
        }

        var temp = WebAndNonWebProjects(logger, withCsprojs);
        if (webNonWeb == WebNonWeb.NonWeb || webNonWeb == WebNonWeb.NonWebCsproj)
        {
            return temp.Item2;
        }
        else if (webNonWeb == WebNonWeb.Web || webNonWeb == WebNonWeb.WebCsproj)
        {
            return temp.Item1;
        }
        else if (webNonWeb == WebNonWeb.Both)
        {
            List<string> lines = new List<string>(temp.Item1.Count + temp.Item2.Count);
            lines.AddRange(temp.Item1);
            lines.AddRange(temp.Item2);
            return lines;
        }

        ThrowEx.NotImplementedCase(webNonWeb);
        return null;
    }
}