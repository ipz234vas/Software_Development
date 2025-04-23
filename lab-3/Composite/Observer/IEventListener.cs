namespace Composite.Observer
{
    public interface IEventListener
    {
        void Update(ISubject subject, EventType eventType, object? data);
    }
}
