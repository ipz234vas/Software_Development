namespace Composite.Observer
{
    public class FormSenderListener : IEventListener
    {
        public void Update(ISubject subject, EventType eventType, object? data)
        {
            Console.WriteLine($"Sending form with data -> {data}...");
        }
    }
}
