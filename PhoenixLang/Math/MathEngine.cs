using NCalc;

namespace PhoenixLang.Math;
    
public static class MathEngine
{
    public static T Evaluate<T>(string? mathExpression)
    {
        try
        {
            var expr = new Expression(mathExpression);
            return (T) expr.Evaluate();
        }
        catch (ArgumentException)
        {
            return default!;
        }
    }   
}