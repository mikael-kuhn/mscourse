using System.Collections.Generic;

namespace Infrastructure
{
    public abstract class BaseService<TIncomingEvent>
        where TIncomingEvent: Event
    {
        private readonly List<Event> _events = new List<Event>();
        public ICollection<Event> Events => _events;
        public abstract void Handle(TIncomingEvent @event);
    }
}
