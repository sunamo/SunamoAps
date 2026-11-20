namespace SunamoAps.Aps.Enums;

public enum SolutionNameMustContains
{
    Text,
    // Not possible to use, in the first phase the projects that could potentially be duplicates are determined. In the second
    SameNameWithDiacritic,
    // FS.GetNameWithoutSeries
    Serie,
    // SH.EndsWithNumber, SHTrim.TrimTrailingNumbersAtEnd
    NumberAtEnd,
    // All projects are taken
    None
}