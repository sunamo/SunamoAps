namespace SunamoAps._sunamo.SunamoDevCodeCore.Interfaces;

internal interface ICsFileFilter
{
    /// <summary>
    /// Get files filtered.
    /// </summary>
    List<string> GetFilesFiltered(string path, string searchPattern, SearchOption searchOption);
}