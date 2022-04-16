using System.Text.RegularExpressions;

namespace PhoenixLang;

public static class Variables
{
    public static Dictionary<string, VariableProps> VariablesList = new(); 
    
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
                    var variableName = match.Value[1..^1];
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

    public static VariableProps? GetVariable(string variableName)
    {
        if (!VariablesList.TryGetValue(variableName, out var variableProps)) return null;
        
        variableProps.Name = variableName;
        return variableProps;
    }
    
    public static void SetVariable(string variableName, string variableType, string variableValue)
    {
        if (GetVariable(variableName) == null)
        {
            var variableProps = new VariableProps
            {
                Name = variableName,
                Type = variableType,
                Value = variableValue
            };
            VariablesList.Add(variableName, variableProps);
        }
        else
        {
            VariablesList[variableName] = new VariableProps
            {
                Name = variableName,
                Type = variableType,
                Value = variableValue
            };
        }
    }

    
}