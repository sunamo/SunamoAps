namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class BTS
{

    /// <summary>
    /// Get value of nullable.
    /// </summary>
    internal static bool GetValueOfNullable(bool? value)
    {
        return value.GetValueOrDefault();
    }
}
