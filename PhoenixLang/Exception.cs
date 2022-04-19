namespace PhoenixLang;

public static class Exception
{
    public static void ThrowException(string description)
    {
        Console.WriteLine($"An exception was thrown: {description}");
    }
}