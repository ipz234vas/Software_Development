using Composite;

namespace Flyweight
{
    public class LightElementTagFactory
    {
        private static Dictionary<string, LightElementTag> _cache = new Dictionary<string, LightElementTag>();

        public static LightElementTag GetLightElementTag(string name, string displayType, string closingType)
        {
            LightElementTag? elementTag = _cache.GetValueOrDefault(name);

            if (elementTag == null)
            {
                elementTag = new LightElementTag(name, displayType, closingType);
                _cache.Add(name, elementTag);
            }

            return elementTag;
        }
    }
}
