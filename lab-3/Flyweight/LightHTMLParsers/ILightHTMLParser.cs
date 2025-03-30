using Composite;

namespace Flyweight.LightHTMLParsers
{
    public interface ILightHTMLParser
    {
        List<LightNode> GetLightHTML();
    }
}
