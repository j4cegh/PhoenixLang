namespace PhoenixLang.Core;

[AttributeUsage(AttributeTargets.Method)]
public class StatementAttribute : Attribute
{
    public string StatementName { get; }
    
    public StatementAttribute(string statementName)
    {
        StatementName = statementName;
    }
}