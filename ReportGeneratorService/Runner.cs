using System.Threading;

namespace Infrastructure
{
    public sealed class Runner
    {
        public static void Run<TIncomingEvent, TService>(IMessageBroker messageBroker, int startFrom = 0)
            where TIncomingEvent: Event
            where TService: BaseService<TIncomingEvent>, new()
        {
            int eventNumber = startFrom;
            
            while (true)
            {
                var message = messageBroker.Read<TIncomingEvent>(eventNumber);
                if (message != null)
                {
                    eventNumber++;
                    var service = new TService();
                    service.Handle(message);

                    foreach (Event e in service.Events)
                    {
                        messageBroker.Write(e);
                    }
                }
                Thread.Sleep(100);
            }

        }
    }
}
