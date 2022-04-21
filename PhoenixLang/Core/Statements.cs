using System.Xml;
using PhoenixLang.Math;
using static PhoenixLang.Core.Attributes;

namespace PhoenixLang.Core;

public static class Statements
{
    public static Dictionary<string, string> Defined = new();
    public static void phoenix_Def(XmlNode statementNode)
    {

        var name = statementNode.Attributes?["name"]?.Value;
        var value = statementNode.Attributes?["value"]?.Value;
        
        if (name == null)
        {
            AttributeNullLog("name");
        }

        if (value == null)
        {
            AttributeNullLog("value");
        }
        
        name ??= "";
        value ??= "";
        
        if (!Defined.ContainsKey(name))
        {
            Defined.Add(name, value);
        }
        else
        {
            Defined[name] = value;
        }
    }

    public static void phoenix_For(XmlNode statementNode) 
    {
        var range = GetAttributeValue(statementNode, "range");
        var iter = GetAttributeValue(statementNode, "iter");

        if (range == null) {
            AttributeNullLog("range");
        }

        if (iter == null) {
            AttributeNullLog("iter");
        }
        
        range ??= "";
        iter ??= "";

        for (var i = 0; i < MathEngine.EvaluateDouble(range); i++)
        {
            Variables.SetVariable(new VariableProps
            {
                Name = iter,
                Type = Type.String,
                Value = i.ToString()
            });
            
            foreach (XmlNode node in statementNode.ChildNodes)
            {
                Language.RunStatements(node);
                Language.RunMethods(node);
            }
        }
        
        
    }
}