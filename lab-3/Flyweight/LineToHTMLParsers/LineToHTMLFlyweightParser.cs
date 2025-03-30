using Composite;

namespace Flyweight.LineToHTMLParsers
{
    public class LineToHTMLFlyweightParser : ILineToHTMLParser
    {
        public LightNode ProcessFirstLine(string line)
        {
            var h1 = new LightElementNode(LightElementTagFactory.GetLightElementTag("h1", "block", "paired"));

            h1.AddChild(new LightTextNode(line));

            return h1;
        }

        public LightNode ProcessLine(string line)
        {
            LightElementNode node;

            if (line.StartsWith(' '))
                node = new LightElementNode(LightElementTagFactory.GetLightElementTag("blockquote", "block", "paired"));
            else if (line.Length < 20)
                node = new LightElementNode(LightElementTagFactory.GetLightElementTag("h2", "block", "paired"));
            else
                node = new LightElementNode(LightElementTagFactory.GetLightElementTag("p", "block", "paired"));

            node.AddChild(new LightTextNode(line));

            return node;
        }
    }
}
