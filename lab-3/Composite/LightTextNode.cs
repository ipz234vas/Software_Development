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

        public override string GetOuterHTML()
        {
            return _content;
        }
    }
}
