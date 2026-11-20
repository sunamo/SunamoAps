namespace SunamoAps.Aps.Args;

/// <summary>
/// Represents the ask for projects or slns args type.
/// </summary>
public class AskForProjectsOrSlnsArgs
{
    /// <summary>
    /// The hint.
    /// </summary>
    public string Hint = string.Empty;
    /// <summary>
    /// The name sln from.
    /// </summary>
    public string? NameSlnFrom = null;
    /// <summary>
    /// The chbl tag.
    /// </summary>
    public object? ChblTag = null;
    /// <summary>
    /// The slns.
    /// </summary>
    public bool Slns = false;
    /// <summary>
    /// The dialog for make sure about replaced with sess i 18 n.
    /// </summary>
    public bool DialogForMakeSureAboutReplacedWithSessI18n = false;
}