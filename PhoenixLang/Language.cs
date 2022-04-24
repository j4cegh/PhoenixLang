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

    private static void BuildStatementsDict()
    {
        var statementInfo = typeof(Statements).GetMethods()
            .Where(x => x.GetCustomAttributes(false).OfType<StatementAttribute>().Any());
        
        foreach (var method in statementInfo)
        {
            void Action(XmlNode node) => method.Invoke(null, new object[] {node});
            MethodsDict.Add(method.Name, Action);
        }
    }
    private static void BuildMethodsDict()
    {
        var methodInfo = typeof(Methods).GetMethods()
            .Where(x => x.GetCustomAttributes(false).OfType<MethodAttribute>().Any());
        
        foreach (var method in methodInfo)
        {
            void Action(XmlNode node) => method.Invoke(null, new object[] {node});
            MethodsDict.Add(method.Name, Action);
        }
    }
    
    private static void BuildDicts()
    {
        BuildStatementsDict();
        BuildMethodsDict();
    }
    
    public void Run()
    {
        BuildDicts();
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
        if (StatementsDict.TryGetValue(node.Name, out var action))
        {
            action(node);
        } 
    }
    
    public static void RunMethods(XmlNode node)
    {
        if (MethodsDict.TryGetValue(node.Name, out var action))
        {
            action(node);
        }
    }

    private static void SetLanguageConstants()
    {
        Variables.SetVariable(new VariableProps
        {
            Name = "__pi__",
            Type = Type.Number,
            Value = Math.PI.ToString(CultureInfo.InvariantCulture)
        });
        
        Variables.SetVariable(new VariableProps
        {
            Name = "__posinf__",
            Type = Type.Number,
            Value = double.PositiveInfinity.ToString(CultureInfo.InvariantCulture)
        });
        
        Variables.SetVariable(new VariableProps
        {
            Name = "__neginf__",
            Type = Type.Number,
            Value = double.NegativeInfinity.ToString(CultureInfo.InvariantCulture)
        });
    }
}