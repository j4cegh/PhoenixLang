using NCalc;

namespace PhoenixLang.Math;
    
public static class MathEngine
{
    /// <summary>
    /// Evaluate a math expression in a string format.
    /// </summary>
    /// <param name="mathExpression">The math expression.</param>
    /// <returns>The math expression, evaluated and turned into the proper format.</returns>
    public static double EvaluateDouble(string? mathExpression)
    {
        var expr = new Expression(mathExpression);
        try
        {
            return (double) expr.Evaluate();
        }
        catch (ArgumentException e)
        {
            return e.ParamName == "Infinity" ? double.MaxValue : default!;
        }
        catch (InvalidCastException)
        {
            return double.TryParse(expr.Evaluate().ToString(), out var final) ? final : default(double);
        }
    }   
}