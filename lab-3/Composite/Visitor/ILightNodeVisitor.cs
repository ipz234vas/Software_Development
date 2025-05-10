namespace Composite.Visitor.Composite
{
    public interface ILightNodeVisitor
    {
        string GetXaml();
        void Visit(Button button);
        void Visit(Image image);
        void Visit(LightContainerElementNode container);
        void Visit(LightNode node);
        void Visit(LightTextNode textNode);
    }
}