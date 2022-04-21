using System.Text.RegularExpressions;

namespace PhoenixLang.Core;

public static class Variables
{
    public static Dictionary<string, VariableProps> VariablesList = new(); 
    
    public static string Replace(string? varString)
    {
        varString ??= "";
        var finalValue = varString;
        
        var matches = Regex.Matches(finalValue!, @"\[[^\]]*\]");
        foreach (Match match in matches)
        {
            var variableName = match.Value[1..^1];
            var variableValue = GetVariable(variableName)?.Value;
            finalValue = finalValue.Replace("[" + variableName + "]", variableValue);
        }

        return finalValue;
    }

    public static VariableProps? GetVariable(string variableName)
    {
        if (!VariablesList.TryGetValue(variableName, out var variableProps)) return null;
        
        variableProps.Name = variableName;
        return variableProps;
    }
    
    public static void SetVariable(VariableProps variable)
    {
        if (GetVariable(variable.Name) == null)
        {
            VariablesList.Add(variable.Name, variable);
        }
        else
        {
            VariablesList[variable.Name] = variable;
        }
    }
}