namespace PhoenixLang.Core;

[AttributeUsage(AttributeTargets.Method)]
public class MethodAttribute : Attribute
{
    public string MethodName = "";
    
    public MethodAttribute(string methodName)
    {
        MethodName = methodName;
    }
}