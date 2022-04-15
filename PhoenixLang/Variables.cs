using System.Text.RegularExpressions;

namespace PhoenixLang;

public static class Variables
{
    public static List<Variable> VariablesList = new(); 
    
    public static string? Replace(string? varString)
    {
        var finalValue = varString;
        try
        {
            if (finalValue != null)
            {
                var matches = Regex.Matches(finalValue, @"\[[^\]]*\]");

                foreach (Match match in matches)
                {
                    var variableName = match.Value.Replace("[", "").Replace("]", "");
                    var variableValue = GetVariable(variableName)?.Value;
                    finalValue = finalValue.Replace("[" + variableName + "]", variableValue);
                }
            }
        }
        catch
        {
            return finalValue;
        }

        return finalValue;
    }

    public static Variable? GetVariable(string variableName)
    {
        foreach (var entry in VariablesList)
        {
            if (entry.Name == variableName)
            {
                return entry;
            }
        }

        return null;
    }

    public static void SetVariable(string variableName, string variableType, string variableValue)
    {
        var variable = new Variable
        {
            Name = variableName,
            Type = variableType,
            Value = variableValue
        };
        VariablesList.Add(variable);
    }
}