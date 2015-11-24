using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;
using Newtonsoft.Json;

namespace Infrastructure
{
    public sealed class MessageBroker : IMessageBroker
    {
        private readonly IEventStoreConnection _connection;

        public MessageBroker()
        {

            _connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@eventstore:1113"));
            _connection.ConnectAsync().Wait();
        }

        public T Read<T>(int eventNumber)
            where T : class
        {
            var result = _connection.ReadEventAsync(typeof(T).Name, eventNumber, false).Result;
            if (result.Event.HasValue)
            {
                string message = Encoding.UTF8.GetString(result.Event.Value.OriginalEvent.Data);
                return JsonConvert.DeserializeObject<T>(message);
            }
            return null;
        }

        public void Write<T>(T message)
        {
            string json = JsonConvert.SerializeObject(message);

            var @event = new EventData(
                Guid.NewGuid(),
                "event",
                false,
                Encoding.UTF8.GetBytes(json),
                Encoding.UTF8.GetBytes(string.Empty)
                );

            _connection.AppendToStreamAsync(message.GetType().Name, ExpectedVersion.Any, @event).Wait();
        }
    }
}
