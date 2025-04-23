namespace Composite.Observer
{
    public class HighlightAdderListener : IEventListener
    {
        public void Update(ISubject subject, EventType eventType, object? data)
        {
            Console.WriteLine($"Highlight added to {subject}");
        }
    }
}
