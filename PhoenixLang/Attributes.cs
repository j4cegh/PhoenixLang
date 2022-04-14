using System.Xml;

namespace PhoenixLang;

public class Attributes
{
    public static string? getAttributeValue(XmlNode node, string attributeName)
    {
        var attributeValue = node.Attributes?[attributeName]?.Value;
        return attributeValue;
    }
}