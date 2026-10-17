namespace SunamoAps._sunamo.SunamoDevCodeBase._public.SunamoData.Data;

public class PushSolutionsData
{
    public bool mergeAndFetch = false;
    public bool addGitignore = false;
    public List<string>? onlyThese = null;
    public bool? cs = null;
    public GitTypesOfMessages checkForGit = GitTypesOfMessages.error | GitTypesOfMessages.fatal;
}