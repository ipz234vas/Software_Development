using Composite.Iterator;
using Composite.Observer;
using Composite.Visitor.Composite;
using System.Collections;
using System.Text;

namespace Composite
{
    public class LightContainerElementNode : LightElementNode, ILightNodeContainer, ISubject, IEnumerable<LightNode>
    {
        private readonly List<LightNode> _children = new();
        private TraversalType _traversalStrategy;

        public LightContainerElementNode(string name, string displayType, string closingType) : base(name, displayType, closingType)
        {

        }

        public void SetTraversalStrategy(TraversalType strategy)
        {
            _traversalStrategy = strategy;
        }

        public IReadOnlyList<LightNode> GetChildren() => _children.AsReadOnly();

        public int GetChildrenCount()
        {
            int count = _children.Count();
            foreach (LightNode child in _children)
                if (child is LightContainerElementNode childElement)
                    count += childElement.GetChildrenCount();
            return count;
        }

        public void AddChild(LightNode child)
        {
            if (_tagInfo.ClosingType == "inline" && child is LightContainerElementNode childElement && childElement._tagInfo.DisplayType == "block")
                throw new ArgumentException($"Cannot add block <{childElement._tagInfo.Name}> inside inline <{_tagInfo.Name}>");

            _children.Add(child);
        }

        public void RemoveChild(LightNode child)
        {
            _children.Remove(child);
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

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        public IEnumerator<LightNode> GetEnumerator()
        {
            if (_traversalStrategy == TraversalType.DepthFirst)
                return new DepthFirstLightHTMLIterator(this);
            if (_traversalStrategy == TraversalType.BreadthFirst)
                return new BreadthFirstLightHTMLIterator(this);

            throw new ArgumentException("Invalid traversal strategy selected. Please choose a valid strategy.");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
