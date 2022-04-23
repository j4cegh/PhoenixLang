using System.Xml;
using PhoenixLang.Core.Math;
using static PhoenixLang.Core.Parameters;

namespace PhoenixLang.Core;

public static class Statements
{
    // ReSharper disable UnusedMember.Global
    public static readonly Dictionary<string, Action<XmlNode>> StatementsDict = new();
    public static readonly Dictionary<string, string> Defined = new();
    
    
    [Statement("Def")]
    public static void Def(XmlNode statementNode)
    {
        var name = statementNode.Attributes?["name"]?.Value;
        var value = statementNode.Attributes?["value"]?.Value;
        
        if (name == null)
            ParameterNullLog("name");
        

        if (value == null) 
            ParameterNullLog("value");

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
    
    [Statement("For")]
    public static void For(XmlNode statementNode) 
    {
        var range = GetParameterValue(statementNode, "range");
        var iter = GetParameterValue(statementNode, "iter");

        if (range == null) {
            ParameterNullLog("range");
        }

        if (iter == null) {
            ParameterNullLog("iter");
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