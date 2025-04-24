namespace Memento
{
    public class TextEditor
    {
        private TextDocument _currentDocument;
        private Stack<IMemento> _snapshots = new();

        public TextEditor(TextDocument textDocument)
        {
            _currentDocument = textDocument;
        }

        public void Save()
        {
            _snapshots.Push(_currentDocument.Save());
        }

        public void Undo()
        {
            if (_snapshots.Count == 0)
            {
                Console.WriteLine("There is no previous versions.");
                return;
            }

            var snapshot = _snapshots.Pop();
            Console.WriteLine("Undo to previous version");
            _currentDocument.Restore(snapshot);
        }
    }
}
