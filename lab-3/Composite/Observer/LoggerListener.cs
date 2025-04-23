namespace Composite.Observer
{
    public class LoggerListener : IEventListener
    {
        public void Update(ISubject subject, EventType eventType, object? data)
        {
            Console.WriteLine($"Event '{eventType}' on {subject} occured, extra data: {data}");
        }
    }
}
