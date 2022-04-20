using System.Diagnostics;
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

            case Type.Number:
            {
                if (double.TryParse(textRaw, out var final))
                {
                    Console.WriteLine(final);
                }
                else
                {
                    Console.WriteLine(0);
                }
                break;
            }
            
            case Type.FNumber:
            {
                if (double.TryParse(Variables.Replace(textRaw), out var final))
                {
                    Console.WriteLine(final);
                }
                else
                {
                    Console.WriteLine(0);
                }
                break;
            }

            case Type.NotFound:
            {
                AttributeNullLog("text_type");
                break;
            }

            case Type.Unidentified:
            default:
            {
                Exception.ThrowException("Could not identify the type of the text.");
                break;
            }
            
        }
    }

    public static void phoenix_ReadConsole(XmlNode methodNode)
    {
        var output = Console.ReadLine()!;
        var toVar = GetAttributeValue(methodNode, "to");
        
        if (toVar != null)
        {
            Variables.SetVariable(new VariableProps
            {
                Name = toVar,
                Type = Type.String,
                Value = output,
            });
        }
    }
}