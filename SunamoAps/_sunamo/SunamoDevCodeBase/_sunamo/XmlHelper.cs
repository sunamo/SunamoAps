namespace SunamoAps._sunamo.SunamoDevCodeBase;

internal class XmlHelper
{
    /// <summary>
    /// Get elements of name.
    /// </summary>
    internal static IList<XmlNode> GetElementsOfName(XmlNode node, string name)
    {
        return node.ChildNodes.WithName(name);
    }

    /// <summary>
    /// Get element of name.
    /// </summary>
    internal static XmlNode GetElementOfName(XmlNode node, string name)
    {
        return node.ChildNodes.First(name);
    }

    /// <summary>
    /// Inner text of node.
    /// </summary>
    internal static string InnerTextOfNode(XmlNode node)
    {
        return node.InnerText;
    }

    /// <summary>
    /// Set attribute.
    /// </summary>
    internal static void SetAttribute(XmlNode node, string attributeName, string attributeValue)
    {
        var element = (XmlElement)node;
        if (element != null)
        {
            element.SetAttribute(attributeName, attributeValue);
            return;
        }
        // Working only when attribute
        var attributeValueExisting = Attr(node, attributeName);
        if (attributeValueExisting == null)
        {
            var newAttribute = node.OwnerDocument!.CreateAttribute(attributeName);
            node.Attributes!.Append(newAttribute);
        }
        node.Attributes![attributeName]!.Value = attributeValue;
    }

    /// <summary>
    /// Attr.
    /// </summary>
    internal static string? Attr(XmlNode node, string attributeName)
    {
        var argument = GetAttributeWithName(node, attributeName);
        if (argument != null)
        {
            return argument.Value;
        }
        return null;
    }

    internal static XmlAttribute? FoundedNode = null;

    /// <summary>
    /// Get attribute with name.
    /// </summary>
    internal static XmlNode? GetAttributeWithName(XmlNode node, string attributeName)
    {
        foreach (XmlAttribute attribute in node.Attributes!)
        {
            if (attribute.Name == attributeName)
            {
                FoundedNode = attribute;
                return attribute;
            }
        }
        return null;
    }
}
