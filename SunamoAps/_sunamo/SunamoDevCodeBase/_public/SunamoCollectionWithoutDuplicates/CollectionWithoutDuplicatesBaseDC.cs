namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal abstract class CollectionWithoutDuplicatesBaseDC<T>
{
    public List<T> Collection { get; set; } = null!;

    public List<string> StringRepresentations { get; set; } = null!;

    private bool? _allowNull = false;

    public bool? AllowNull
    {
        get => _allowNull;
        set
        {
            _allowNull = value;
            if (value.HasValue && value.Value)
            {
                StringRepresentations = new List<string>(InitialCapacity);
            }
        }
    }

    public static bool BreakOnConstruction { get; set; } = false;

    private int InitialCapacity { get; set; } = 10000;

    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesBaseDC.
    /// </summary>
    public CollectionWithoutDuplicatesBaseDC()
    {
        if (BreakOnConstruction)
        {
            System.Diagnostics.Debugger.Break();
        }
        Collection = new List<T>();
    }

    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesBaseDC.
    /// </summary>
    public CollectionWithoutDuplicatesBaseDC(int capacity)
    {
        this.InitialCapacity = capacity;
        Collection = new List<T>(capacity);
    }

    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesBaseDC.
    /// </summary>
    public CollectionWithoutDuplicatesBaseDC(IList<T> initialList)
    {
        Collection = new List<T>(initialList.ToList());
    }

    /// <summary>
    /// Add.
    /// </summary>
    public bool Add(T value)
    {
        bool result = false;
        var containsResult = Contains(value);
        if (containsResult.HasValue)
        {
            if (!containsResult.Value)
            {
                Collection.Add(value);
                result = true;
            }
        }
        else
        {
            if (!AllowNull.HasValue)
            {
                Collection.Add(value);
                result = true;
            }
        }
        if (result)
        {
            if (IsComparingByString())
            {
                StringRepresentations.Add(ItemString);
            }
        }
        return result;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    protected abstract bool IsComparingByString();

    protected string ItemString { get; set; } = null!;

    /// <summary>
    /// Contains.
    /// </summary>
    public abstract bool? Contains(T value);

    /// <summary>
    /// Add with index.
    /// </summary>
    public abstract int AddWithIndex(T value);

    /// <summary>
    /// Index of.
    /// </summary>
    public abstract int IndexOf(T value);

    private List<T> WasNotAdded { get; set; } = new List<T>();

    /// <summary>
    /// Add range.
    /// </summary>
    public List<T> AddRange(IList<T> list)
    {
        WasNotAdded.Clear();
        foreach (var item in list)
        {
            if (!Add(item))
            {
                WasNotAdded.Add(item);
            }
        }
        return WasNotAdded;
    }
}
