namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal abstract class CollectionOnDriveBase<T>(ILogger logger) : List<T>
{
    protected bool removeDuplicates = false;
    protected CollectionOnDriveArgs args = new();
    private bool isSaving;
    private FileSystemWatcher? watcher;
    /// <summary>
    /// Clear with save.
    /// </summary>
    internal async Task ClearWithSave()
    {
        Clear();
        await Save();
    }
    /// <summary>
    /// Load.
    /// </summary>
    internal abstract Task Load(bool removeDuplicates);
    /// <summary>
    /// Save.
    /// </summary>
    internal async Task Save()
    {
        isSaving = true;
        await FileAsync.WriteAllTextAsync(args.path, SHJoin.JoinNL(this));
        isSaving = false;
    }
    /// <summary>
    /// To string.
    /// </summary>
    public override string ToString()
    {
        return SHJoin.JoinNL(this);
    }
    /// <summary>
    /// W changed.
    /// </summary>
    private void W_Changed(object sender, FileSystemEventArgs e)
    {
        if (!isSaving)
            Load(removeDuplicates);
    }
}
