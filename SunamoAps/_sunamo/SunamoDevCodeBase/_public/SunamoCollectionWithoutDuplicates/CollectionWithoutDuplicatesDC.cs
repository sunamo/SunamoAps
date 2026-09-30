namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class CollectionWithoutDuplicatesDC<T> : CollectionWithoutDuplicatesBaseDC<T>
{
    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesDC.
    /// </summary>
    public CollectionWithoutDuplicatesDC() : base()
    {
    }

    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesDC.
    /// </summary>
    public CollectionWithoutDuplicatesDC(int count) : base(count)
    {
    }

    /// <summary>
    /// Initializes a new instance of CollectionWithoutDuplicatesDC.
    /// </summary>
    public CollectionWithoutDuplicatesDC(IList<T> list) : base(list)
    {
    }

    /// <summary>
    /// Add with index.
    /// </summary>
    public override int AddWithIndex(T value)
    {
        if (IsComparingByString())
        {
            if (Contains(value).GetValueOrDefault())
            {

            }
            else
            {
                Add(value);
                return Collection.Count - 1;
            }
        }
        int index = Collection.IndexOf(value);
        if (index == -1)
        {
            Add(value);
            return Collection.Count - 1;
        }
        return index;
    }

    /// <summary>
    /// Contains.
    /// </summary>
    public override bool? Contains(T value)
    {
        if (IsComparingByString())
        {
            ItemString = value!.ToString()!;
            return StringRepresentations.Contains(ItemString);
        }
        else
        {
            if (!Collection.Contains(value))
            {
                if (EqualityComparer<T>.Default.Equals(value, default(T)))
                {
                    return null;
                }
                return false;
            }
        }
        return true;
    }

    /// <summary>
    /// Index of.
    /// </summary>
    public override int IndexOf(T value)
    {
        if (IsComparingByString())
        {
            return StringRepresentations.IndexOf(value!.ToString()!);
        }
        int index = Collection.IndexOf(value);
        if (index == -1)
        {
            Collection.Add(value);
            return Collection.Count - 1;
        }
        return index;
    }

    /// <summary>
    /// Is comparing by string.
    /// </summary>
    protected override bool IsComparingByString() => AllowNull.HasValue && AllowNull.Value;
}
