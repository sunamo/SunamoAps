namespace SunamoAps._sunamo.SunamoDevCodeCore;

// Filter for C# files with configurable filtering rules
// Cannot be derived from FiltersNotTranslateAble to make finding instances of CsFileFilter easier
/// <summary>
/// Represents the cs file filter type.
/// </summary>
public partial class CsFileFilter : ICsFileFilter
{
    private static bool? _returnValue;
    private ContainsArgs? containsArgs;
    private EndArgs? endArgs;
    // In default is everything in false
    // Call some Set* method
    /// <summary>
    /// Initializes a new instance of CsFileFilter.
    /// </summary>
    public CsFileFilter()
    {
    }

    private static bool? returnValue
    {
        get => _returnValue;
        set
        {
            if (value.HasValue)
                if (!value.Value)
                {
                }

            _returnValue = value;
        }
    }

    /// <summary>
    /// Get files filtered.
    /// </summary>
    public List<string> GetFilesFiltered(string path, string searchPattern, SearchOption searchOption)
    {
        var files = Directory.GetFiles(path, searchPattern, searchOption).ToList();
        files.RemoveAll(AllowOnly);
        files.RemoveAll(AllowOnlyContains);
        return files;
    }

    // A2 is also for master.designer.cs and aspx.designer.cs
    // A2,3 can be null
    /// <summary>
    /// Allow only.
    /// </summary>
    public static bool AllowOnly(string filePath, EndArgs end, ContainsArgs containsArgs, ref bool hasEndMatch, bool isAlsoCheckingEnds)
    {
        returnValue = null;
        if (isAlsoCheckingEnds && end != null)
        {
            hasEndMatch = true;
            if (!end.designerCs && filePath.EndsWith(End.designerCsPp))
                returnValue = false;
            if (!end.xamlCs && filePath.EndsWith(End.xamlCsPp))
                returnValue = false;
            if (!end.sharedCs && filePath.EndsWith(End.sharedCsPp))
                returnValue = false;
            if (!end.iCs && filePath.EndsWith(End.iCsPp))
                returnValue = false;
            if (!end.gICs && filePath.EndsWith(End.gICsPp))
                returnValue = false;
            if (!end.gCs && filePath.EndsWith(End.gCsPp))
                returnValue = false;
            if (!end.tmp && filePath.EndsWith(End.tmpPp))
                returnValue = false;
            if (!end.TMP && filePath.EndsWith(End.TMPPp))
                returnValue = false;
            if (!end.DesignerCs && filePath.EndsWith(End.DesignerCsPp))
                returnValue = false;
            if (!end.notTranslateAble && filePath.EndsWith(End.NotTranslateAblePp))
                returnValue = false;
        }

        if (returnValue.HasValue)
            // Always false
            return returnValue.Value;
        hasEndMatch = false;
        if (containsArgs != null)
        {
            if (!containsArgs.binFp && filePath.Contains(Contains.binFp))
                returnValue = false;
            if (!containsArgs.objFp && filePath.Contains(Contains.objFp))
                returnValue = false;
            if (!containsArgs.tildaRF && filePath.Contains(Contains.tildaRFFp))
                returnValue = false;
        }

        if (returnValue.HasValue)
            // Always false
            return returnValue.Value;
        return true;
    }

    /// <summary>
    /// Allow only contains.
    /// </summary>
    public static bool AllowOnlyContains(string itemPath, ContainsArgs containsArgs)
    {
        if (!containsArgs.objFp && itemPath.Contains(@"\obj\"))
            return false;
        if (!containsArgs.binFp && itemPath.Contains(@"\bin\"))
            return false;
        if (!containsArgs.tildaRF && itemPath.Contains(@"RF~"))
            return false;
        return true;
    }

    /// <summary>
    /// Represents the contains type.
    /// </summary>
    public class Contains
    {
        /// <summary>
        /// The obj fp.
        /// </summary>
        public static string objFp = @"\obj\";
        /// <summary>
        /// The bin fp.
        /// </summary>
        public static string binFp = @"\bin\";
        /// <summary>
        /// The tilda RF fp.
        /// </summary>
        public static string tildaRFFp = "~RF";
    }

    /// <summary>
    /// Represents the contains args type.
    /// </summary>
    public class ContainsArgs
    {
        /// <summary>
        /// The bin fp.
        /// </summary>
        public bool binFp;
        /// <summary>
        /// The obj fp.
        /// </summary>
        public bool objFp;
        /// <summary>
        /// The tilda RF.
        /// </summary>
        public bool tildaRF;
        // false which not to index, true which to index
        /// <summary>
        /// Initializes a new instance of ContainsArgs.
        /// </summary>
        public ContainsArgs(bool objFp, bool binFp, bool tildaRF)
        {
            this.objFp = objFp;
            this.binFp = binFp;
            this.tildaRF = tildaRF;
        }
    }

    /// <summary>
    /// Represents the end type.
    /// </summary>
    public class End
    {
        /// <summary>
        /// The not translate able pp constant.
        /// </summary>
        public const string NotTranslateAblePp = "NotTranslateAble";
        /// <summary>
        /// The designer cs pp constant.
        /// </summary>
        public const string designerCsPp = ".designer.cs";
        /// <summary>
        /// The designer cs pp constant.
        /// </summary>
        public const string DesignerCsPp = ".Designer.cs";
        /// <summary>
        /// The xaml cs pp constant.
        /// </summary>
        public const string xamlCsPp = ".xaml.cs";
        /// <summary>
        /// The shared cs pp constant.
        /// </summary>
        public const string sharedCsPp = "Shared.cs";
        /// <summary>
        /// The i cs pp constant.
        /// </summary>
        public const string iCsPp = ".i.cs";
        /// <summary>
        /// The g i cs pp constant.
        /// </summary>
        public const string gICsPp = ".g.i.cs";
        /// <summary>
        /// The g cs pp constant.
        /// </summary>
        public const string gCsPp = ".g.cs";
        /// <summary>
        /// The tmp pp constant.
        /// </summary>
        public const string tmpPp = ".tmp";
        /// <summary>
        /// The TMP pp constant.
        /// </summary>
        public const string TMPPp = ".TMP";
    }
}