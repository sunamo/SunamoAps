namespace SunamoAps.Aps;

/// <summary>
/// Represents the aps plugin static type.
/// </summary>
public class ApsPluginStatic
{
    /// <summary>
    /// Gets the cmd.
    /// </summary>
    public bool Cmd => ApsMainWindow.Instance.cmd;

    /// <summary>
    /// Gets the fwss.
    /// </summary>
    public static FoldersWithSolutionsList Fwss => FoldersWithSolutions.Fwss;

    /// <summary>
    /// The used repository.
    /// </summary>
    public static RepositoryLocal UsedRepository
    {
        set => FoldersWithSolutions.UsedRepository = value;
        get => FoldersWithSolutions.UsedRepository;
    }
}