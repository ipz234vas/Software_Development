namespace Memento
{
    public class TextDocument
    {
        private string _content = "";

        public void Append(string text)
        {
            _content += text;
        }

        public void Display()
        {
            Console.WriteLine("Document: " + _content);
        }

        public IMemento Save()
        {
            return new DocumentMemento(_content);
        }

        public void Restore(IMemento memento)
        {
            if (memento is DocumentMemento docMemento)
            {
                _content = docMemento.Content;
            }
            else throw new ArgumentException("The snapshot is not of type DocumentMemento!");
        }

        private class DocumentMemento : IMemento
        {
            public string Content { get; }

            public DocumentMemento(string content)
            {
                Content = content;
            }
        }
    }

}
