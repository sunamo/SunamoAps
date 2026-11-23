namespace SunamoAps.Aps.Helpers;

/// <summary>
/// Represents the sunamo web helper type.
/// </summary>
public class SunamoWebHelper
{
    /// <summary>
    /// List of sunamo web projects.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="getFileSettings">The get file settings.</param>
    /// <returns>The list of sunamo web projects result.</returns>
    public static async Task<List<string>> ListOfSunamoWebProjects(ILogger logger, GetFileSettings getFileSettings)
    {
        var csprojs = new List<string>();
        foreach (var item in ApsMainWindow.Instance.Fwss)
        {
            foreach (var sln in item.GetSolutions(RepositoryLocal.Vs17))
            {
                if (await ApsHelper.Instance.IsWebProject(logger, sln, getFileSettings))
                {
                    SolutionFolder.GetCsprojs(logger, sln);
                    csprojs.AddRange(sln.ProjectsGetCsprojs);
                }
            }
        }
        return csprojs;
    }
}