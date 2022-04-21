using System.Drawing;
using System.Globalization;
using System.Xml;
using Pastel;
using PhoenixLang.Math;
using static PhoenixLang.Core.Attributes;
using static PhoenixLang.Core.Typing;
using static PhoenixLang.Core.Statements;

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
                if (Defined.GetValueOrDefault("numColor") != "true")
                {
                    Console.WriteLine(MathEngine.EvaluateDouble(textRaw));
                }
                else
                {
                    Console.WriteLine(MathEngine.EvaluateDouble(textRaw)
                        .ToString(CultureInfo.InvariantCulture)
                        .Pastel(Color.Green)
                    );
                }
                break;
            }
            
            case Type.FNumber:
            {
                if (Defined.GetValueOrDefault("numColor") != "true")
                {
                    Console.WriteLine(MathEngine.EvaluateDouble(
                        Variables.Replace(textRaw))
                    );
                }
                else
                {
                    Console.WriteLine(MathEngine.EvaluateDouble(
                        Variables.Replace(textRaw))
                        .ToString(CultureInfo.InvariantCulture)
                        .Pastel(Color.Green)
                    );
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
        var toVar = GetAttributeValue(methodNode, "to") ?? 
                    GetAttributeValue(methodNode, "pipe") ?? 
                    GetAttributeValue(methodNode, "pipeTo");

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