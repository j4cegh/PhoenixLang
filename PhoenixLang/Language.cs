using System.Xml;
using static PhoenixLang.Methods;

namespace PhoenixLang;
public class Language
{
    private XmlDocument document;
    public Language(string fileName)
    {
        document = new XmlDocument();
        document.Load(fileName);
        InterpretNodes();
    }

    private void InterpretNodes()
    {
        foreach (XmlNode rootNode in document.ChildNodes)
        {
            if (rootNode.Name != "Program") continue;

            foreach (XmlNode programNode in rootNode.ChildNodes)
            {
                if (programNode.Name == "Main")
                {
                    RunMainNode(programNode);
                }
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

    private void RunStatements(XmlNode node)
    {
        
    }
    
    private void RunMethods(XmlNode node)
    {
        switch (node.Name)
        {
            case "OutputConsole":
            {
                phoenix_OutputConsole(node);
                break;
            }            
        }
        
    }
}