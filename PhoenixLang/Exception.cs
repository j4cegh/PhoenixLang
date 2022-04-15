namespace PhoenixLang;

public static class Exception
{
    public static void ThrowException(string description, string fileName)
    {
        Console.WriteLine($"An exception was thrown in {fileName}: {description}");
    }
}