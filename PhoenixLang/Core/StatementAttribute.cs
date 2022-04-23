namespace PhoenixLang.Core;

[AttributeUsage(AttributeTargets.Method)]
public class StatementAttribute : Attribute
{
    public StatementAttribute(string statementName)
    {
        
    }
}