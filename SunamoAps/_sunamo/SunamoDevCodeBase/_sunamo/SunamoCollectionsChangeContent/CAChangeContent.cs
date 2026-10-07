namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class CAChangeContent
{
    /// <summary>
    /// Remove null or empty.
    /// </summary>
    private static void RemoveNullOrEmpty(ChangeContentArgsDC args, List<string> list)
    {
        if (args != null)
        {
            if (args.RemoveNull)
            {
                list.Remove(null!);
            }
            if (args.RemoveEmpty)
            {
                for (int index = list.Count - 1; index >= 0; index--)
                {
                    if (list[index].Trim() == string.Empty)
                    {
                        list.RemoveAt(index);
                    }
                }
            }
        }
    }

    // Direct edit - Changes content of list using provided function with 0 additional parameters
    // If not every element fulfills pattern, it is good to remove null (or values returned if can't be changed) from result
    /// <summary>
    /// Change content0.
    /// </summary>
    internal static List<string> ChangeContent0(ChangeContentArgsDC args, List<string> list, Func<string, string> func)
    {
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = func.Invoke(list[index]);
        }
        RemoveNullOrEmpty(args, list);
        return list;
    }

    #region Switch first and second argument
    /// <summary>
    /// Change content switch12.
    /// </summary>
    internal static List<string> ChangeContentSwitch12<Arg1>(List<string> list, Func<Arg1, string, string> func, Arg1 argument)
    {
        for (int index = 0; index < list.Count; index++)
        {
            list[index] = func.Invoke(argument, list[index]);
        }
        return list;
    }

    // Direct edit input collection
    // Changes content of list using provided function with 1 additional parameter
    /// <summary>
    /// Change content.
    /// </summary>
    internal static List<string> ChangeContent<Arg1>(ChangeContentArgsDC args, List<string> list, Func<string, Arg1, string> func, Arg1 argument, Func<Arg1, string, string>? funcSwitch12 = null)
    {
        args ??= new();
        if (args.SwitchFirstAndSecondArg)
        {
            list = ChangeContentSwitch12<Arg1>(list, funcSwitch12!, argument);
        }
        else
        {
            for (int index = 0; index < list.Count; index++)
            {
                list[index] = func.Invoke(list[index], argument);
            }
        }
        RemoveNullOrEmpty(args, list);
        return list;
    }
    #endregion
}
