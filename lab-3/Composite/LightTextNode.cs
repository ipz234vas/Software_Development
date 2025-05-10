using Composite.Visitor.Composite;

namespace Composite
{
    public class LightTextNode : LightNode
    {
        private string _content;

        public LightTextNode(string content)
        {
            _content = content;
        }

        public void SetContent(string content)
        {
            _content = content;
        }

        public override string GetInnerHTML()
        {
            return _content;
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.Visit(this);
        }

        protected override string GetOpenTag()
        {
            return string.Empty;
        }

        protected override string GetCloseTag()
        {
            return string.Empty;
        }
    }
}
