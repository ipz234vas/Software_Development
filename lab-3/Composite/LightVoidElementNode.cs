using System.Text;

namespace Composite
{
    public class LightVoidElementNode : LightElementNode
    {
        public LightVoidElementNode(string name, string displayType) : base(name, displayType, "self_closing") { }
        public override string GetInnerHTML()
        {
            return string.Empty;
        }

        public override string GetOuterHTML()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('<').Append(_tagInfo.Name);

            if (_cssClasses.Any())
                stringBuilder.Append(" class=\"").Append(string.Join(' ', _cssClasses)).Append('"');

            stringBuilder.Append("/>");

            return stringBuilder.ToString();
        }
    }
}
