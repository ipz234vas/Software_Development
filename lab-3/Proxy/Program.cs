using Proxy;

//var rootPath = "../../../"; //for visual studio
var rootPath = ""; //for cli "dotnet run"

ISmartTextReader smartTextReader = new SmartTextReader();
smartTextReader.ReadFileToArray(rootPath + "test.txt");

Console.WriteLine("Smart Text Checker:\n");
ISmartTextReader smartTextChecker = new SmartTextChecker(smartTextReader);
smartTextChecker.ReadFileToArray(rootPath + "limited/test.txt");
Console.WriteLine();
smartTextChecker.ReadFileToArray("notexist.txt");

Console.WriteLine("\n\nSmart Text Reader Locker:\n");
ISmartTextReader smartTextReaderLocker = new SmartTextReaderLocker(smartTextChecker);
smartTextReaderLocker.ReadFileToArray(rootPath + "limited/test.txt");
Console.WriteLine();
smartTextReaderLocker.ReadFileToArray(rootPath + "test.txt");