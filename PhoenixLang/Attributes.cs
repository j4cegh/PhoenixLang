using System.Xml;

namespace PhoenixLang;

public static class Attributes
{
    // ReSharper disable once InconsistentNaming
    public static string? getAttributeValue(XmlNode node, string attributeName)
    {
        var attributeValue = node.Attributes?[attributeName]?.Value;
        return attributeValue;
    }
}