using System.Collections;

namespace Composite.Iterator
{
    public class BreadthFirstLightHTMLIterator : IEnumerator<LightNode>
    {
        private readonly Queue<LightNode> _queue = new();
        private LightNode _current;
        private readonly LightNode _root;

        public BreadthFirstLightHTMLIterator(LightNode root)
        {
            _root = root;
            Reset();
        }

        public LightNode Current => _current;
        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (_queue.Count == 0) return false;

            _current = _queue.Dequeue();

            if (_current is ILightNodeContainer container)
            {
                var children = container.GetChildren();
                foreach (var child in children)
                {
                    _queue.Enqueue(child);
                }
            }

            return true;
        }

        public void Reset()
        {
            _queue.Clear();
            _queue.Enqueue(_root);
            _current = null;
        }

        public void Dispose() { }
    }
}
