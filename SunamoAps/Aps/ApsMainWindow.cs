namespace SunamoAps.Aps;

/// <summary>
/// Represents the aps main window type.
/// </summary>
public class ApsMainWindow : IMainWindowCsFileFilter, IAbstractCatalog<string, string>
{
    #region IAbstractCatalog
    internal static AbstractCatalog<string, string>? AbstractCatalogInstance = null;

    internal AbstractCatalog<string, string>? ac => AbstractCatalogInstance;
    #endregion

    #region IFoldersWithSolutions
    /// <summary>
    /// The folders with solutions instance.
    /// </summary>
    public static IFoldersWithSolutions? FoldersWithSolutionsInstance = null;

    /// <summary>
    /// Gets the fwss.
    /// </summary>
    public FoldersWithSolutionsList Fwss => FoldersWithSolutions.Fwss;
    #endregion

    /// <summary>
    /// The instance.
    /// </summary>
    public static ApsMainWindow Instance = new ApsMainWindow();

    /// <summary>
    /// Aps main window.
    /// </summary>
    /// <returns>The aps main window result.</returns>
    public ApsMainWindow()
    {
    }

    /// <summary>
    /// The main window aps.
    /// </summary>
    public static IMainWindowAps? MainWindowAps = null;

    /// <summary>
    /// Gets or sets the cmd.
    /// </summary>
    public bool cmd { get { return MainWindowAps == null ? true : MainWindowAps.Cmd; } set { if (MainWindowAps != null) MainWindowAps.Cmd = value; } }

    #region ICsFileFilter
    /// <summary>
    /// The cs file filter instance.
    /// </summary>
    public static CsFileFilter? CsFileFilterInstance = null;

    /// <summary>
    /// Gets the cs file filter.
    /// </summary>
    public CsFileFilter CsFileFilter { get => CsFileFilterInstance!; set => CsFileFilterInstance = value; }
    #endregion
}