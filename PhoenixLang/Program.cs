using PhoenixLang;

var fileLocation = Environment.GetCommandLineArgs()[1];
var language = new Language(fileLocation);
language.Run();