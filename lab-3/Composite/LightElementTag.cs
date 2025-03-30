namespace Composite
{
    public class LightElementTag
    {
        public string Name { get; }
        public string DisplayType { get; }
        public string ClosingType { get; }

        public LightElementTag(string name, string displayType, string closingType)
        {
            Name = name;
            DisplayType = displayType;
            ClosingType = closingType;
        }
    }
}
