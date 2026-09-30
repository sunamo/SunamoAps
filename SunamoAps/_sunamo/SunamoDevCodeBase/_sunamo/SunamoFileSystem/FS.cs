namespace SunamoAps._sunamo.SunamoDevCodeBase;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal partial class FS
{
    /// <summary>
    /// Delete folders which not contains.
    /// </summary>
    internal static void DeleteFoldersWhichNotContains(string rootPath, string folderPattern, IList<string> mustContainPatterns)
    {
        var folders = Directory.GetDirectories(rootPath, folderPattern, SearchOption.AllDirectories).ToList();
        for (int i = folders.Count - 1; i >= 0; i--)
        {
            if (CA.ReturnWhichContainsIndexes(folders[i], mustContainPatterns).Count != 0)
            {
                folders.RemoveAt(i);
            }
        }

        foreach (var folder in folders)
        {
        //FS.DeleteF
        }
    }

    /// <summary>
    /// Is absolute path.
    /// </summary>
    internal static bool IsAbsolutePath(string path)
    {
        return !String.IsNullOrWhiteSpace(path) && path.IndexOfAny(System.IO.Path.GetInvalidPathChars()) == -1 && Path.IsPathRooted(path) && !Path.GetPathRoot(path)!.Equals(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal);
    }

    /// <summary>
    /// Get absolute path2.
    /// </summary>
    internal static string GetAbsolutePath2(string relativePath, string baseDirectory)
    {
        var absolutePath = GetAbsolutePath(baseDirectory, relativePath);
        return Path.GetFullPath(absolutePath);
    }

    /// <summary>
    /// File to directory.
    /// </summary>
    internal static void FileToDirectory(ref string path)
    {
        if (!path.EndsWith("\""))
            path = GetDirectoryName(path);
    }

    /// <summary>
    /// Get absolute path.
    /// </summary>
    internal static string GetAbsolutePath(string baseDirectory, string relativePath)
    {
        FileToDirectory(ref baseDirectory);
        var currentDirectoryPrefix = "./";
        var parentDirectoryPrefix = "../";
        var parentDirectoryCount = 0;
        while (true)
            if (relativePath.StartsWith(currentDirectoryPrefix))
            {
                relativePath = relativePath.Substring(currentDirectoryPrefix.Length);
            }
            else if (relativePath.StartsWith(parentDirectoryPrefix))
            {
                parentDirectoryCount++;
                relativePath = relativePath.Substring(parentDirectoryPrefix.Length);
            }
            else
            {
                break;
            }

        var pathTokens = GetTokens(relativePath);
        pathTokens = pathTokens.Skip(parentDirectoryCount).ToList();
        pathTokens.Insert(0, baseDirectory);
        var result = Combine(pathTokens.ToArray());
        result = GetFullPath(result);
        return result;
    }

    /// <summary>
    /// Is windows path format.
    /// </summary>
    internal static bool IsWindowsPathFormat(string argValue)
    {
        if (string.IsNullOrWhiteSpace(argValue))
            return false;
        var badFormat = false;
        if (argValue.Length < 3)
            return badFormat;
        if (!char.IsLetter(argValue[0]))
            badFormat = true;
        if (char.IsLetter(argValue[1]))
            badFormat = true;
        if (argValue.Length > 2)
            if (argValue[1] != '\\' && argValue[2] != '\\')
                badFormat = true;
        return !badFormat;
    }

    /// <summary>
    /// First char upper.
    /// </summary>
    internal static string FirstCharUpper(ref string result)
    {
        if (IsWindowsPathFormat(result))
            result = SH.FirstCharUpper(result);
        return result;
    }

    /// <summary>
    /// Get full path.
    /// </summary>
    internal static string GetFullPath(string path)
    {
        var result = Path.GetFullPath(path);
        FirstCharUpper(ref result);
        return result;
    }

    /// <summary>
    /// Combine worker.
    /// </summary>
    private static string CombineWorker(bool isFirstCharUpper, bool isFile, params string[] pathParts)
    {
        for (var i = 0; i < pathParts.Length; i++)
            pathParts[i] = pathParts[i].TrimStart('\\');
        var result = Path.Combine(pathParts);
        if (result[2] != '\\')
            result = result.Insert(2, "\"");
        if (isFirstCharUpper)
            result = SH.FirstCharUpper(ref result);
        else
            result = SH.FirstCharUpper(ref result);
        if (!isFile)
            // Cant return with end slash becuase is working also with files
            WithEndSlash(ref result);
        return result;
    }

    /// <summary>
    /// Combine.
    /// </summary>
    internal static string Combine(params string[] pathParts)
    {
        return CombineWorker(true, false, pathParts);
    }

    /// <summary>
    /// Get tokens.
    /// </summary>
    internal static List<string> GetTokens(string path)
    {
        var delimiter = "";
        if (path.Contains("\""))
            delimiter = "\"";
        else if (path.Contains("/"))
            delimiter = "/";
        else
        {
            ThrowEx.NotImplementedCase(path);
        }

        return SHSplit.Split(path, delimiter);
    }

    /// <summary>
    /// Replace directory throw exception if from doesnt exists.
    /// </summary>
    internal static string ReplaceDirectoryThrowExceptionIfFromDoesntExists(string path, string folderWithProjectsFolders, string folderWithTemporaryMovedContentWithoutBackslash)
    {
        path = SH.FirstCharUpper(path);
        folderWithProjectsFolders = SH.FirstCharUpper(folderWithProjectsFolders);
        folderWithTemporaryMovedContentWithoutBackslash = SH.FirstCharUpper(folderWithTemporaryMovedContentWithoutBackslash);
        if (!ThrowEx.NotContains(path, folderWithProjectsFolders))
            // Here can never accomplish when exc was throwed
            return path;
        // Here can never accomplish when exc was throwed
        return path.Replace(folderWithProjectsFolders, folderWithTemporaryMovedContentWithoutBackslash);
    }

    /// <summary>
    /// Make unc long path.
    /// </summary>
    internal static string MakeUncLongPath(ref string path)
    {
        if (!path.StartsWith(@"\\?\"))
        {
        // V ASP.net mi vrátilo u každé directory.exists false. Byl jsem pod ApplicationPoolIdentity v IIS a bylo nastaveno Full Control pro IIS AppPool\DefaultAppPool
        }

        return path;
    }

    /// <summary>
    /// Make unc long path.
    /// </summary>
    internal static string MakeUncLongPath(string path)
    {
        return MakeUncLongPath(ref path);
    }
}
