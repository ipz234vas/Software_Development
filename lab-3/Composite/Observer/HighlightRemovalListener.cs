namespace Composite.Observer
{
    public class HighlightRemovalListener : IEventListener
    {
        public void Update(ISubject subject, EventType eventType, object? data)
        {
            Console.WriteLine($"Highlight removed from {subject}");
        }
    }
}
