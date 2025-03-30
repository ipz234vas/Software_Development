using Flyweight.LightHTMLParsers;
using Flyweight.LineToHTMLParsers;

class Program
{
    static void Main()
    {
        //var filePath = "book.txt"; //for cli "dotnet run"
        var filePath = "../../../book.txt"; //for visual studio
        MeasureMemoryUsage("Without Flyweight", () =>
            new LightHTMLFileParser(filePath, new LineToHTMLParser()));

        MeasureMemoryUsage("With Flyweight", () =>
            new LightHTMLFileParser(filePath, new LineToHTMLFlyweightParser()));
    }

    static void MeasureMemoryUsage(string parserName, Func<ILightHTMLParser> getParser)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoryBefore = GC.GetTotalMemory(true);

        ILightHTMLParser lightHTMLConverter = getParser();
        var nodes = lightHTMLConverter.GetLightHTML();

        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();

        long memoryAfter = GC.GetTotalMemory(true);

        Console.WriteLine($"{parserName} takes {memoryAfter / 1024 - memoryBefore / 1024} KB.");
    }
}
