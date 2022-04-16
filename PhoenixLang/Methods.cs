using System.Xml;
using static PhoenixLang.Attributes;
using static PhoenixLang.Types;

namespace PhoenixLang;

public static class Methods
{
    public static void phoenix_OutputConsole(XmlNode methodNode)
    {
        var textType = InterpretType(GetAttributeValue(methodNode, "text_type"));
        var textRaw = GetAttributeValue(methodNode, "text");

        if (textRaw == null)
            AttributeNullLog("text");
        
            
        switch (textType)
        {
            case Type.StringL:
            {
                Console.WriteLine(textRaw);
                break;
            }

            case Type.String:
            {
                Console.WriteLine(Variables.Replace(textRaw));
                break;
            }

            case Type.NotFound:
            {
                AttributeNullLog("text_type");
                break;
            }
            
            case Type.Unidentified:
            {
                Exception.ThrowException("Could not identify the type of the text.", Language.FileName);
                break;
            }


            default:
            {
                break;
            }
        }
    }

    public static void phoenix_PauseConsole(XmlNode methodNode)
    {
        
    }
}