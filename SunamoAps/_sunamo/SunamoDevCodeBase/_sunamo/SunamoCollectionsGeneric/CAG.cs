namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class CAG
{

    /// <summary>
    /// Get duplicities.
    /// </summary>
    internal static List<T> GetDuplicities<T>(List<T> list)
    {
        return GetDuplicities<T>(list, out _);
    }

    /// <summary>
    /// Get duplicities.
    /// </summary>
    internal static List<T> GetDuplicities<T>(List<T> list, out List<T> alreadyProcessed)
    {
        alreadyProcessed = new List<T>(list.Count);
        var duplicated = new CollectionWithoutDuplicatesDC<T>();
        foreach (var currentItem in list)
        {
            if (alreadyProcessed.Contains(currentItem))
            {
                duplicated.Add(currentItem);
            }
            else
            {
                alreadyProcessed.Add(currentItem);
            }
        }
        return duplicated.Collection;
    }
}
