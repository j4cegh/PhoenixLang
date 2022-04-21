using PhoenixLang;

if (Environment.GetCommandLineArgs().Length > 1)
{
    var fileLocation = Environment.GetCommandLineArgs()[1];
    var language = new Language(fileLocation);
    language.Run();    
}
else
{
    Console.WriteLine("Usage: PhoenixLang.exe <file.xml>");
}
