using System.Text;

namespace Composite.Visitor
{
    namespace Composite
    {
        public class LightNodeToXamlVisitor : ILightNodeVisitor
        {
            private StringBuilder _xamlOutput = new();

            public string GetXaml() => _xamlOutput.ToString();

            public void Visit(Button button)
            {
                _xamlOutput.AppendLine($"<Button>");
                foreach (var child in button.GetChildren())
                {
                    child.Accept(this);
                }
                _xamlOutput.AppendLine($"</Button>");
            }

            public void Visit(Image image)
            {
                _xamlOutput.AppendLine($"<Image Source=\"{image.GetHref()}\" />");
            }

            public void Visit(Input input)
            {
                _xamlOutput.AppendLine($"<TextBox Text=\"{input.Text}\"/>");
            }

            public void Visit(LightContainerElementNode container)
            {
                _xamlOutput.AppendLine($"<StackPanel>");
                foreach (var child in container.GetChildren())
                {
                    child.Accept(this);
                }
                _xamlOutput.AppendLine($"</StackPanel>");
            }

            public void Visit(LightTextNode textNode)
            {
                _xamlOutput.AppendLine($"<TextBlock>{textNode.GetInnerHTML()}</TextBlock>");
            }

            public void Visit(LightNode node)
            {
                Console.WriteLine($"Unknown element: {node}");
            }
        }
    }
}
