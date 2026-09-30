namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class SHJoin
{
    /// <summary>
    /// Join nl.
    /// </summary>
    internal static string JoinNL<T>(List<T> list)
    {
        var strings = list.ConvertAll(item => item!.ToString());
        return string.Join("\n", strings);
    }

    /// <summary>
    /// Join nl.
    /// </summary>
    internal static string JoinNL(List<string> list) => string.Join("\n", list);
}
