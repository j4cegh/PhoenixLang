using System.Xml;

namespace PhoenixLang.Core;

public static class Parameters
{ 
    public static string? GetParameterValue(XmlNode node, string parameterName)
    {
        var parameterValue = node.Attributes?[parameterName]?.Value;
        return parameterValue;
    }

    public static void ParameterNullLog(string parameterName)
    {
        Exception.ThrowException($"The parameter {parameterName} is null.");
        Environment.Exit(1);
    }
}