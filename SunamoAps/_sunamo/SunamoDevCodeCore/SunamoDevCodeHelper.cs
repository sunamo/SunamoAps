namespace SunamoAps._sunamo.SunamoDevCodeCore;

internal class SunamoDevCodeHelper
{

    /// <summary>
    /// Remove temporary files vs.
    /// </summary>
    public static void RemoveTemporaryFilesVS(List<string> files)
    {
        var list = VisualStudioTempFseWrapped.FoldersInSolutionToDelete;

        // todo list je zde List<string>, chce jen string, později to analyzovat

        //As foldersInProjectToDelete dont have contains WildCard, set false
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersInProjectToDelete;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersAnywhereToDelete;
        CA.RemoveWhichContainsList(files, list, false);

        list = VisualStudioTempFseWrapped.FoldersInSolutionDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersInProjectDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
        list = VisualStudioTempFseWrapped.FoldersAnywhereDownloaded;
        CA.RemoveWhichContainsList(files, list, false);
    }
}