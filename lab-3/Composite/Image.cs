using Composite.Strategy;
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

        public void Display()
        {
            _strategy.LoadImage(_href);
        }

        public override string GetOuterHTML()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('<').Append(_tagInfo.Name);

            if (_cssClasses.Any())
                stringBuilder.Append(" class=\"").Append(string.Join(' ', _cssClasses)).Append('"');

            stringBuilder.Append($" src=\"{_href}\"");

            stringBuilder.Append("/>");

            return stringBuilder.ToString();
        }
    }
}
