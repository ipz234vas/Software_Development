using Composite;

namespace Flyweight.LineToHTMLParsers
{
    public class LineToHTMLParser : ILineToHTMLParser
    {
        public LightNode ProcessFirstLine(string line)
        {
            var h1 = new LightElementNode(new LightElementTag("h1", "block", "paired"));

            h1.AddChild(new LightTextNode(line));

            return h1;
        }

        public LightNode ProcessLine(string line)
        {
            LightElementNode node;

            if (line.StartsWith(' '))
                node = new LightElementNode(new LightElementTag("blockquote", "block", "paired"));
            else if (line.Length < 20)
                node = new LightElementNode(new LightElementTag("h2", "block", "paired"));
            else
                node = new LightElementNode(new LightElementTag("p", "block", "paired"));

            node.AddChild(new LightTextNode(line));

            return node;
        }
    }
}
