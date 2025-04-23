namespace Composite.Observer
{
    public interface ISubject
    {
        void InvokeEvent(EventType eventType, object? data = null);
        void AddEventListener(EventType eventType, IEventListener listener);
        void RemoveEventListener(EventType eventType, IEventListener listener);
    }
}
