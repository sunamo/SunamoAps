namespace SunamoAps.Aps.Enums;

/// <summary>
/// Represents the solution name must contains type.
/// </summary>
public enum SolutionNameMustContains
{
    /// <summary>
    /// The text value.
    /// </summary>
    Text,
    // Not possible to use, in the first phase the projects that could potentially be duplicates are determined. In the second
    /// <summary>
    /// The same name with diacritic value.
    /// </summary>
    SameNameWithDiacritic,
    // FS.GetNameWithoutSeries
    /// <summary>
    /// The serie value.
    /// </summary>
    Serie,
    // SH.EndsWithNumber, SHTrim.TrimTrailingNumbersAtEnd
    /// <summary>
    /// The number at end value.
    /// </summary>
    NumberAtEnd,
    // All projects are taken
    /// <summary>
    /// The none value.
    /// </summary>
    None
}