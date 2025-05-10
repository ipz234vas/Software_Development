using Composite.Strategy;
using Composite.Visitor.Composite;
using System.Text;

namespace Composite
{
    public class Image : LightVoidElementNode
    {
        private IImageLoadStrategy _strategy;
        private string _href;
        public Image(string href) : base("img", "inline-block")
        {
            SetHref(href);
        }

        public void SetHref(string href)
        {
            _href = href;
            _strategy = ImageLoadStrategyFactory.GetByImageSource(href);
        }

        public string GetHref() => _href;

        public void Display()
        {
            _strategy.LoadImage(_href);
        }

        protected override string GetAttributes()
        {
            return base.GetAttributes() + $" src=\"{_href}\"";
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
