using Composite;

namespace Flyweight.LineToHTMLParsers
{
    public interface ILineToHTMLParser
    {
        LightNode ProcessFirstLine(string line);
        LightNode ProcessLine(string line);
    }
}
