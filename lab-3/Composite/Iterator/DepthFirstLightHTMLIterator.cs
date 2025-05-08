using System.Collections;

namespace Composite.Iterator
{
    public class DepthFirstLightHTMLIterator : IEnumerator<LightNode>
    {
        private readonly Stack<LightNode> _stack = new();
        private LightNode _current;
        private readonly LightNode _root;

        public DepthFirstLightHTMLIterator(LightNode root)
        {
            _root = root;
            Reset();
        }

        public LightNode Current => _current;
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_stack.Count == 0) return false;

            _current = _stack.Pop();

            if (_current is ILightNodeContainer container)
            {
                var children = container.GetChildren();

                for (int i = children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(children[i]);
                }
            }

            return true;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push(_root);
            _current = null;
        }

        public void Dispose() { }
    }
}
