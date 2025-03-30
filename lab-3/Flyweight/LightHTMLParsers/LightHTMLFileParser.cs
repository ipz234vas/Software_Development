using Composite;
using Flyweight.LineToHTMLParsers;

namespace Flyweight.LightHTMLParsers
{
    public class LightHTMLFileParser : ILightHTMLParser
    {
        private readonly string _filePath;
        private readonly ILineToHTMLParser _lineParser;

        public LightHTMLFileParser(string filePath, ILineToHTMLParser parser)
        {
            _filePath = filePath;
            _lineParser = parser;
        }

        public List<LightNode> GetLightHTML()
        {
            var nodes = new List<LightNode>();

            try
            {
                using (var reader = new StreamReader(_filePath))
                {
                    string line;
                    bool isFirstLine = true;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isFirstLine)
                        {
                            _lineParser.ProcessFirstLine(line);
                            isFirstLine = false;
                        }

                        var node = _lineParser.ProcessLine(line);
                        if (node != null)
                        {
                            nodes.Add(node);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }

            return nodes;
        }
    }
}
