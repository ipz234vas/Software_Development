using Proxy;

ISmartTextReader smartTextReader = new SmartTextReader();
smartTextReader.ReadFileToArray("../../../test.txt");

Console.WriteLine("Smart Text Checker:\n");
ISmartTextReader smartTextChecker = new SmartTextChecker(smartTextReader);
smartTextChecker.ReadFileToArray("../../../limited/test.txt");
Console.WriteLine();
smartTextChecker.ReadFileToArray("notexist.txt");

Console.WriteLine("\n\nSmart Text Reader Locker:\n");
ISmartTextReader smartTextReaderLocker = new SmartTextReaderLocker(smartTextChecker);
smartTextReaderLocker.ReadFileToArray("../../../limited/test.txt");
Console.WriteLine();
smartTextReaderLocker.ReadFileToArray("../../../test.txt");