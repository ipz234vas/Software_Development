using System.Text;

namespace Composite
{
    public class LightElementNode : LightNode
    {
        private readonly string _name;
        private readonly string _displayType;
        private readonly string _closingType;
        private readonly HashSet<string> _cssClasses = new();
        private readonly List<LightNode> _children = new();

        public LightElementNode(string name, string displayType, string closingType)
        {
            _name = name;
            _displayType = displayType;
            _closingType = closingType;
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
            if (_displayType == "inline" && child is LightElementNode childElement && childElement._displayType == "block")
                throw new ArgumentException($"Cannot add block <{childElement._name}> inside inline <{_name}>");

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
            stringBuilder.Append('<').Append(_name);

            if (_cssClasses.Any())
                stringBuilder.Append(" class=\"").Append(string.Join(' ', _cssClasses)).Append('"');

            if (_closingType == "self_closing")
                stringBuilder.Append("/>");

            else if (_closingType == "paired")
                stringBuilder
                    .Append('>')
                    .Append(GetInnerHTML())
                    .Append("</").Append(_name).Append('>');

            return stringBuilder.ToString();
        }
    }
}
