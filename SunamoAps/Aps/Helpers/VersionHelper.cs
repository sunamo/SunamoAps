namespace SunamoAps.Aps.Helpers;

/// <summary>
/// Represents the version helper type.
/// </summary>
public class VersionHelper
{
    /// <summary>
    /// Remove parts which is zero.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <returns>The remove parts which is zero result.</returns>
    public static string RemovePartsWhichIsZero(Version version)
    {
        const string dotZero = ".0";

        var text = version.ToString();
        while (text.EndsWith(dotZero))
        {
            text = SHTrim.Trim(text, dotZero);
        }
        return text;
    }
}