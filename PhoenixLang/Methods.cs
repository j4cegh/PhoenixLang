using System.Xml;
using static PhoenixLang.Attributes;

namespace PhoenixLang;

public static class Methods
{
    public static void phoenix_OutputConsole(XmlNode methodNode)
    {
        Console.WriteLine(getAttributeValue(methodNode, "text"));
    }
}