using System.Text;

namespace Composite
{
    public class LightElementNode : LightNode
    {
        private readonly LightElementTag _tagInfo;
        private readonly HashSet<string> _cssClasses = new();
        private readonly List<LightNode> _children = new();

        public LightElementNode(LightElementTag tagInfo)
        {
            _tagInfo = tagInfo;
        }

        public int GetChildrenCount()
        {
            int count = _children.Count();
            foreach (LightNode child in _children)
                if (child is LightElementNode childElement)
                    count += childElement.GetChildrenCount();
            return count;
        }

        public void AddChild(LightNode child)
        {
            if (_tagInfo.ClosingType == "inline" && child is LightElementNode childElement && childElement._tagInfo.DisplayType == "block")
                throw new ArgumentException($"Cannot add block <{childElement._tagInfo.Name}> inside inline <{_tagInfo.Name}>");

            _children.Add(child);
        }

        public void RemoveChild(LightNode child)
        {
            _children.Remove(child);
        }

        public void AddClass(string className)
        {
            _cssClasses.Add(className);
        }

        public void RemoveClass(string className)
        {
            _cssClasses.Remove(className);
        }

        public override string GetInnerHTML()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (LightNode child in _children)
                stringBuilder.Append(child.GetOuterHTML());
            return stringBuilder.ToString();
        }

        public override string GetOuterHTML()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('<').Append(_tagInfo.Name);

            if (_cssClasses.Any())
                stringBuilder.Append(" class=\"").Append(string.Join(' ', _cssClasses)).Append('"');

            if (_tagInfo.ClosingType == "self_closing")
                stringBuilder.Append("/>");

            else if (_tagInfo.ClosingType == "paired")
                stringBuilder
                    .Append('>')
                    .Append(GetInnerHTML())
                    .Append("</").Append(_tagInfo.Name).Append('>');

            return stringBuilder.ToString();
        }
    }
}
