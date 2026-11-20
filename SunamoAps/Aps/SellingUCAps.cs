namespace SunamoAps.Aps;

/// <summary>
/// Represents the selling UC aps type.
/// </summary>
public class SellingUCAps
{
    internal static CollectionOnDrive? ToSelling = null;

    /// <summary>
    /// Init.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="getFileSettings">The get file settings.</param>
    public async Task Init(ILogger logger, GetFileSettings getFileSettings)
    {
        ToSelling = new CollectionOnDrive(logger);
        await ToSelling.Load(getFileSettings("ToSelling.txt"), false);
    }
}