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

        protected override string GetCloseTag()
        {
            return string.Empty;
        }
    }
}
