namespace PhoenixLang.Core;

[AttributeUsage(AttributeTargets.Method)]
public class MethodAttribute : Attribute
{
    public string MethodName { get; }
    
    public MethodAttribute(string methodName)
    {
        MethodName = methodName;
    }
}