namespace PhoenixLang.Core;

public static class Types
{
    public static Type InterpretType(string? type)
    {
        return type switch
        {
            "string" => Type.String,
            "stringl" => Type.StringL,
            null => Type.NotFound,
            _ => Type.Unidentified
        };
    }
}