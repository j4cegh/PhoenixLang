using System.Data;

namespace PhoenixLang.Core;

public static class MathEngine
{
    public static T Evaluate<T>(string mathExpression)
    {
        try
        {
            return (T) new DataTable().Compute(mathExpression, null);
        }
        catch (EvaluateException)
        {
            return default!;
        } 
    }   
}