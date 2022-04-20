using System.Xml;
using PhoenixLang.Core;
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
        Variables.SetVariable(new VariableProps
        {
            Name = "poop",
            Type = Type.String,
            Value = "yooo"
        });
        
        Variables.SetVariable(new VariableProps
        {
            Name = "poop2",
            Type = Type.String,
            Value = "yooo2"
        });
        
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

    private void RunMainNode(XmlNode mainNode)
    {
        foreach (XmlNode node in mainNode.ChildNodes)
        {
            RunStatements(node);
            RunMethods(node);
        }
    }

    private static void RunStatements(XmlNode node)
    {
        
    }
    
    private static void RunMethods(XmlNode node)
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
}