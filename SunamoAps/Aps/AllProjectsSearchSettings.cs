namespace SunamoAps.Aps;

internal static partial class AllProjectsSearchSettings
{
    static string? fileNotTranslate = null;
    //
    internal static List<string>? DontReplaceReferencesIn { get; set; } = null;
    internal static
    async Task<List<string>>
 DontReplaceReferencesInLoad(GetFileSettings getFileSettings)
    {
        if (DontReplaceReferencesIn == null)
        {
            var fileName = getFileSettings("dontReplaceReferencesIn.txt");
            DontReplaceReferencesIn =
    await
 TF.ReadAllLines(fileName);
            // Inlined from SF.RemoveComments - removes empty lines and lines starting with '#'
            DontReplaceReferencesIn = DontReplaceReferencesIn!.Where(line => !string.IsNullOrWhiteSpace(line) && !line.StartsWith("#")).ToList();
        }
        return DontReplaceReferencesIn;
    }
    internal static string fileFoldersVsTemplate = "";
    internal static CollectionOnDrive? _foldersVsTemplate = null;
    internal static async Task<CollectionOnDrive> GetFoldersVsTemplate(ILogger logger, GetFileSettings getFileSettings)
    {
        if (_foldersVsTemplate == null)
        {
            fileFoldersVsTemplate = getFileSettings("foldersVsTemplate.txt");
            _foldersVsTemplate = new CollectionOnDrive(logger);
            await _foldersVsTemplate.Load(fileFoldersVsTemplate, false);
        }
        return _foldersVsTemplate;
    }
    internal static CollectionOnDrive? _filesNotToTranslate = null;
    internal static async Task<CollectionOnDrive> GetFilesNotToTranslate(ILogger logger, GetFileSettings getFileSettings)
    {
        if (_filesNotToTranslate == null)
        {
            fileNotTranslate = getFileSettings("notToTranslateFiles.txt");
            _filesNotToTranslate = new CollectionOnDrive(logger);
            await _filesNotToTranslate.Load(fileNotTranslate, false);
        }
        return _filesNotToTranslate;
    }
    #region webProjects
    internal static string fileWebProjects = "";
    internal static CollectionOnDrive? _webProjects = null;
    internal static async Task<CollectionOnDrive> GetWebProjects(ILogger logger, GetFileSettings getFileSettings)
    {
        if (_webProjects == null)
        {
            fileWebProjects = getFileSettings("webProjects.txt");
            _webProjects = new CollectionOnDrive(logger);
            await _webProjects.Load(fileWebProjects, false);
        }
        return _webProjects;
    }
    #endregion
    #region webProjects
    internal static string fileAddWpfProjectsToSln = "";
    internal static CollectionOnDrive? _addWpfProjectsToSln = null;
    internal static async Task<CollectionOnDrive> GetAddWpfProjectsToSln(ILogger logger, GetFileSettings getFileSettings)
    {
        if (_addWpfProjectsToSln == null)
        {
            fileAddWpfProjectsToSln = getFileSettings("AddWpfProjectsToSln.txt");
            _addWpfProjectsToSln = new CollectionOnDrive(logger);
            await _addWpfProjectsToSln.Load(fileAddWpfProjectsToSln, false);
        }
        return _addWpfProjectsToSln;
    }
    #endregion
    static Dictionary<string, Regex>? _webProjectsWildCard = null;
    internal static async Task<Dictionary<string, Regex>> GetWebProjectsWildCard(ILogger logger, GetFileSettings getFileSettings)
    {
        if (_webProjectsWildCard == null)
        {
            _webProjectsWildCard = new Dictionary<string, Regex>();
            foreach (var item in await GetWebProjects(logger, getFileSettings))
            {
                _webProjectsWildCard.Add(item, Wildcard.CreateInstance(item));
            }
        }
        return _webProjectsWildCard;
    }
    // Contains zero-indexed folders to search in, e.g. 1=D:\Documents\ but whether to search is in sectionSearchFoldersChecked
    const string sectionSearchFolders = "SearchFolders";

    // Contains zero-indexed bool values, index refers to folder in sectionSearchFolders and bool says whether to search in this folder
    const string sectionSearchFoldersChecked = "SearchFoldersChecked";
    internal static string PathAutoYes(GetFileData getFileData)
    {
        var pathToTranslate = getFileData("AutoYes.txt");
        return pathToTranslate;
    }
    internal static string PathAutoNo(GetFileData getFileData)
    {
        var pathNotToTranslate = getFileData("AutoNo.txt");
        return pathNotToTranslate;
    }
    internal static string PathManuallyYes(GetFileData getFileData)
    {
        var pathToTranslate = getFileData("ManuallyYes.txt");
        return pathToTranslate;
    }
    internal static string PathManuallyNo(GetFileData getFileData)
    {
        var pathNotToTranslate = getFileData("ManuallyNo.txt");
        return pathNotToTranslate;
    }
    // Returns whether the path exists in search paths
    internal static bool ExistsSearchFolderByPath(string path)
    {
        path = FS.WithEndSlash(path);
        for (int index = 0; index < 1000; index++)
        {
            if (!ExistsFolderSearchBySerie())
            {
                break;
            }
            else
            {
                if (GetSearchFolderNormalized() == path)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Returns all paths in which to search
    internal static List<string> GetAllNormalizedSearchFolders()
    {
        List<string> folders = new List<string>();
        for (int index = 0; index < 1000; index++)
        {
            var exists = ExistsFolderSearchBySerie();
            if (!exists)
            {
                break;
            }
            else
            {
                folders.Add(GetSearchFolderNormalized());
            }
        }
        return folders;
    }
}