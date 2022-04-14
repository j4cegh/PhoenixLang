using System.Xml;
using static PhoenixLang.Attributes;

namespace PhoenixLang;

public static class Methods
{
    public static void phoenix_OutputConsole(XmlNode methodNode)
    {
        var textType = getAttributeValue(methodNode, "text_type");
    }
}