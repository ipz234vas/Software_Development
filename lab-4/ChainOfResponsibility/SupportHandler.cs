namespace ChainOfResponsibility
{
    public abstract class SupportHandler : ISupportHandler
    {
        protected ISupportHandler? _next;
        public void SetNext(ISupportHandler handler)
        {
            _next = handler;
        }

        public virtual bool Handle(string request) => _next?.Handle(request) ?? false;
    }
}
