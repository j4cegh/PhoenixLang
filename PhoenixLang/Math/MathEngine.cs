using NCalc;

namespace PhoenixLang.Math;
    
public static class MathEngine
{
    /// <summary>
    /// Evaluate a math expression in a string format.
    /// </summary>
    /// <param name="mathExpression">The math expression.</param>
    /// <returns>The math expression, evaluated and turned into a double.</returns>
    public static double EvaluateDouble(string? mathExpression)
    {
        try
        {
            var expr = new Expression(mathExpression);
            return (double) expr.Evaluate();
        }
        catch (ArgumentException e)
        {
            return e.ParamName == "Infinity" ? double.MaxValue : default!;
        }
    }   
}