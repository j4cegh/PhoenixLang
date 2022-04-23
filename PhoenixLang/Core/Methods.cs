using System.Drawing;
using System.Globalization;
using System.Xml;
using Pastel;
using PhoenixLang.Math;
using static PhoenixLang.Core.Parameters;
using static PhoenixLang.Core.Typing;
using static PhoenixLang.Core.Statements;

namespace PhoenixLang.Core;

public static class Methods
{
    // ReSharper disable UnusedMember.Global
    public static Dictionary<string, Action<XmlNode>> MethodsDict = new();

    
    [Method("OutputConsole")]
    public static void OutputConsole(XmlNode methodNode)
    {
        var textType = InterpretType(GetParameterValue(methodNode, "text_type"));
        var textRaw = GetParameterValue(methodNode, "text");

        if (textRaw == null)
            ParameterNullLog("text");
        
        textRaw ??= "";
            
        switch (textType)
        {
            case Type.String:
            {
                Console.WriteLine(textRaw.Replace("\\n", "\n"));
                break;
            }

            case Type.FString:
            {
                Console.WriteLine(Variables.Replace(textRaw.Replace("\\n", "\n")));
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
                ParameterNullLog("text_type");
                break;
            }

            case Type.Unidentified:
            default:
            {
                Exception.ThrowException("Could not identify the type of the text.");
                Environment.Exit(1);
                break;
            }
            
        }
    }
    
    [Method("ReadConsole")]
    public static void ReadConsole(XmlNode methodNode)
    {
        var output = Console.ReadLine()!;
        var toVar = GetParameterValue(methodNode, "to") ?? 
                    GetParameterValue(methodNode, "pipe") ?? 
                    GetParameterValue(methodNode, "pipeTo");

        if (toVar != null)
        {
            Variables.SetVariable(new VariableProps
            {
                Name = toVar,
                Type = Type.String,
                Value = output
            });
        }
    }
    
    [Method("OutputNewLine")]
    public static void OutputNewLine(XmlNode methodNode)
    {
        Console.WriteLine();
    }
}