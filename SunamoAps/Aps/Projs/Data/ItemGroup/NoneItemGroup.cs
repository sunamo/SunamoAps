namespace SunamoAps.Aps.Projs.Data.ItemGroup;

/// <summary>
/// Represents the none item group type.
/// </summary>
public class NoneItemGroup : ItemGroupElement
{
    /// <summary>
    /// Initializes a new instance of the none item group class.
    /// </summary>
    public NoneItemGroup() : base(string.Empty)
    {
    }

    /// <summary>
    /// To xml.
    /// </summary>
    /// <param name="xmlDocument">The xml document.</param>
    /// <returns>The to xml result.</returns>
    public override XmlNode ToXml(XmlDocument xmlDocument)
    {
        var generator = new XmlGenerator();
        generator.WriteNonPairTagWithAttr(VsProjectItemTypes.None, "Include", Include);
        XmlNode node = XH.ReturnXmlNode(generator.ToString()!)!;
        return node;
    }
}