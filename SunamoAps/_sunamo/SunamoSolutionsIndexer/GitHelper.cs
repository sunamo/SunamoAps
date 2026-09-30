namespace SunamoAps._sunamo.SunamoSolutionsIndexer;

internal class GitHelper
{

    /// <summary>
    /// Push solution.
    /// </summary>
    public static
        async Task<bool>
        PushSolution(bool release, GitBashBuilder gitBashBuilder, string pushArgs, string commitMessage,
            string fullPathFolder, PushSolutionsData pushSolutionsData, GitBashBuilder gitStatus,
            Func<List<string>, Task<List<List<string>>>> psInvoke)
    {
        // 1. better solution is commented only getting files
        var countFiles = 0;
        if (release) countFiles = Directory.GetFiles(fullPathFolder, "*.*", SearchOption.AllDirectories).Length;

        if (fullPathFolder.Contains("SunamoCzAdmin"))
        {
        }

        if (countFiles > 0)
        {
            gitStatus.Clear();
            gitStatus.Cd(fullPathFolder);
            gitStatus.Status();

            var result = new List<List<string>>(new List<List<string>>([new List<string>(), new List<string>()]));
            // 2. or powershell
            if (release)
                result =
                    await
                        psInvoke(gitStatus.Commands);

            var statusOutput = result[1];
            // If solution has changes
            var hasChanges = !statusOutput.Any(line => line.Contains("nothing to commit"));
            if (!hasChanges)
                foreach (var lineStatus in statusOutput)
                {
                    _ = lineStatus.Trim();
                    if (statusOutput.Contains("modified:"))
                        if (statusOutput.Contains(".gitignore"))
                        {
                            hasChanges = true;
                            break;
                        }
                }

            if (!hasChanges)
                foreach (var lineStatus in statusOutput)
                {
                    //
                    _ = lineStatus.Trim();
                    if (statusOutput.Contains("but the upstream is gone"))
                    {
                        hasChanges = true;
                        break;
                    }
                }

            // or/and is a git repository
            var isGitRepository =
                !statusOutput.Any(line => line.Contains("not a git repository")); // CA.ReturnWhichContains(, ).Count == 0;
            if (hasChanges && isGitRepository)
            {
                gitBashBuilder.Cd(fullPathFolder);

                if (pushSolutionsData.mergeAndFetch) gitBashBuilder.Fetch();

                gitBashBuilder.Add("*");

                gitBashBuilder.Commit(false, commitMessage);

                if (pushSolutionsData.mergeAndFetch) gitBashBuilder.Merge("--allow-unrelated-histories");

                if (pushSolutionsData.addGitignore) gitBashBuilder.Add(".gitignore");

                gitBashBuilder.Push(pushArgs);

                gitBashBuilder.AppendLine();

                // Dont run, better is paste into powershell due to checking errors
                //var git = gitBashBuilder.Commands;
                //PowershellRunner.Instance.Invoke(git);

                return true;
            }
        }

        return false;
    }
}
