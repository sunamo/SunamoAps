namespace SunamoAps._sunamo.SunamoDevCodeBase;

public class PushSolutionsData
{
    public bool mergeAndFetch = false;
    public bool addGitignore = false;
    public List<string>? onlyThese = null;
    public bool? cs = null;
    public GitTypesOfMessages checkForGit = GitTypesOfMessages.error | GitTypesOfMessages.fatal;
}
