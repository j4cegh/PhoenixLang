namespace PhoenixLang.Core;

public static class Typing
{
    public static Type InterpretType(string? type)
    {
        return type switch
        {
            "string" => Type.String,
            "fstring" => Type.FString,
            null => Type.NotFound,
            _ => Type.Unidentified
        };
    }
}