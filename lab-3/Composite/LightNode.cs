using Composite.Visitor.Composite;

namespace Composite
{
    public abstract class LightNode
    {
        public abstract string GetInnerHTML();
        public abstract string GetOuterHTML();
        public abstract void Accept(ILightNodeVisitor visitor);
    }
}
