using System.Xml;
using static PhoenixLang.Core.Attributes;
using static PhoenixLang.Core.Typing;

namespace PhoenixLang.Core;

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
            case Type.String:
            {
                Console.WriteLine(textRaw);
                break;
            }

            case Type.FString:
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
                Exception.ThrowException("Could not identify the type of the text.");
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