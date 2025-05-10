using Composite.Visitor.Composite;

namespace Composite
{
    public class Input : LightVoidElementNode
    {
        public string Text { get; set; } = string.Empty;

        public Input() : base("input", "inline-block")
        {
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
