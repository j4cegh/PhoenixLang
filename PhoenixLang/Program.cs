using System.Xml;
using PhoenixLang;

var language = new Language(/*Environment.GetCommandLineArgs()[1]*/ "Test.xml");
language.Run();