using Composite.Observer;
using Composite.Visitor.Composite;
using Flyweight;
using System.Text;

namespace Composite
{
    public abstract class LightElementNode : LightNode, ISubject
    {
        protected readonly LightElementTag _tagInfo;
        protected readonly HashSet<string> _cssClasses = new();
        protected readonly Dictionary<EventType, List<IEventListener>> _listeners = new();

        public LightElementNode(string name, string displayType, string closingType)
        {
            _tagInfo = LightElementTagFactory.GetLightElementTag(name, displayType, closingType);
        }

        public void AddClass(string className)
        {
            _cssClasses.Add(className);
        }

        public void RemoveClass(string className)
        {
            _cssClasses.Remove(className);
        }

        public override string ToString()
        {
            return '<' + _tagInfo.Name + '>';
        }

        public void InvokeEvent(EventType eventType, object? data = null)
        {
            if (_listeners.TryGetValue(eventType, out var list))
            {
                foreach (var listener in list)
                    listener.Update(this, eventType, data);
            }
        }

        public void AddEventListener(EventType eventType, IEventListener listener)
        {
            if (!_listeners.ContainsKey(eventType))
                _listeners[eventType] = new List<IEventListener>();
            if (!_listeners[eventType].Contains(listener))
                _listeners[eventType].Add(listener);
        }

        public void RemoveEventListener(EventType eventType, IEventListener listener)
        {
            if (_listeners.TryGetValue(eventType, out var list))
                list.Remove(listener);
        }

        protected override string GetCloseTag()
        {
            return "</" + _tagInfo.Name + '>';
        }

        protected override string GetOpenTag()
        {
            var tagStart = GetOpenTagStart();
            var attributes = GetAttributes();
            var tagEnd = GetOpenTagEnd();

            return tagStart + attributes + tagEnd;
        }

        protected virtual string GetOpenTagStart()
        {
            return "<" + _tagInfo.Name;
        }

        protected virtual string GetAttributes()
        {
            var stringBuilder = new StringBuilder();
            if (_cssClasses.Any())
                stringBuilder.Append(" class=\"").Append(string.Join(' ', _cssClasses)).Append('"');
            return stringBuilder.ToString();
        }

        protected virtual string GetOpenTagEnd()
        {
            if (_tagInfo.ClosingType == "self_closing")
                return "/>";

            else if (_tagInfo.ClosingType == "paired")
                return ">";

            return string.Empty;
        }

        public override void Accept(ILightNodeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
