namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal sealed class CollectionOnDrive : CollectionOnDriveBase<string>
{
    private readonly ILogger _logger;
    /// <summary>
    /// Initializes a new instance of CollectionOnDrive.
    /// </summary>
    internal CollectionOnDrive(ILogger logger) : base(logger)
    {
        _logger = logger;
    }
    /// <summary>
    /// Load.
    /// </summary>
    internal async Task Load(string path, bool removeDuplicates)
    {
        if (_logger == NullLogger.Instance)
        {
            ThrowEx.UseNonDummyCollection();
        }
        args.path = path;
        await Load(removeDuplicates);
    }
    /// <summary>
    /// Load.
    /// </summary>
    internal override async Task Load(bool removeDuplicates)
    {
        if (File.Exists(args.path))
        {
            Clear();
            var rows = SHGetLines.GetLines(await FileAsync.ReadAllTextAsync(args.path));
            rows = rows.Where(line => line.Trim() != string.Empty).ToList();
            AddRange(rows);
            if (removeDuplicates)
            {
                var data = this.ToList();
                Clear();
                data = data.Distinct().ToList();
                AddRange(data);
                await Save();
            }
        }
    }
}
