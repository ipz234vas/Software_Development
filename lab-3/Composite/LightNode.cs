using Composite.Visitor.Composite;

namespace Composite
{
    public abstract class LightNode
    {
        public abstract string GetInnerHTML();
        public string GetOuterHTML()
        {
            var openTag = GetOpenTag();
            var content = GetInnerHTML();
            var closeTag = GetCloseTag();

            return openTag + content + closeTag;
        }
        protected abstract string GetOpenTag();
        protected abstract string GetCloseTag();
        public abstract void Accept(ILightNodeVisitor visitor);
    }
}
