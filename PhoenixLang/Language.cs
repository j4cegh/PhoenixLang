using System.Globalization;
using System.Xml;
using PhoenixLang.Core;
using static PhoenixLang.Core.Statements;
using static PhoenixLang.Core.Methods;
using Type = PhoenixLang.Core.Type;

namespace PhoenixLang;
public class Language
{
    private readonly XmlDocument _document;
    private static string _fileName = "";
    
    public Language(string fileName)
    {
        _fileName = fileName;
        _document = new XmlDocument();
        _document.Load(fileName);
    }

    public void Run()
    {
        SetLanguageConstants();
        InterpretNodes();
    }
    
    private void InterpretNodes()
    {
        if (_document.DocumentElement is not {Name: "Program"}) return;
        
        foreach (XmlNode programNode in _document.DocumentElement.ChildNodes)
        {
            if (programNode.Name == "Main")
            {
                RunMainNode(programNode);
            }
        }
    }

    private static void RunMainNode(XmlNode mainNode)
    {
        foreach (XmlNode node in mainNode.ChildNodes)
        {
            RunStatements(node);
            RunMethods(node);
        }
    }

    public static void RunStatements(XmlNode node)
    {
        switch (node.Name)
        {
            case "Def":
            {
                phoenix_Def(node);
                break;
            }
            case "For":
            {
                phoenix_For(node);
                break;
            }
        }
    }
    
    public static void RunMethods(XmlNode node)
    {
        switch (node.Name)
        {
            case "OutputConsole":
            {
                phoenix_OutputConsole(node);
                break;
            }
            case "ReadConsole":
            {
                phoenix_ReadConsole(node);
                break;
            }
        }
        
    }

    private static void SetLanguageConstants()
    {
        Variables.SetVariable(new VariableProps
        {
            Name = "__pi__",
            Type = Type.Number,
            Value = System.Math.PI.ToString(CultureInfo.InvariantCulture)
        });
        
        Variables.SetVariable(new VariableProps
        {
            Name = "__posinf__",
            Type = Type.Number,
            Value = double.PositiveInfinity.ToString(CultureInfo.InvariantCulture)
        });
    }
}