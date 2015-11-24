using System;
using System.Net;
using System.Text;
using EventStore.ClientAPI;

namespace Infrastructure
{
    public sealed class MessageBroker
    {
        private readonly IEventStoreConnection _connection;

        public MessageBroker()
        {

            _connection = EventStoreConnection.Create(new Uri("tcp://admin:changeit@127.0.0.1:1113"));
            _connection.ConnectAsync().Wait();
        }

        public string Read(string stream, int eventNumber)
        {
            var result = _connection.ReadEventAsync(stream, eventNumber, false).Result;
            if (result.Event.HasValue)
            {
                return Encoding.UTF8.GetString(result.Event.Value.OriginalEvent.Data);
            }
            return null;
        }

        public void Write(string stream, string message)
        {
            var @event = new EventData(
                Guid.NewGuid(),
                "event",
                false,
                Encoding.UTF8.GetBytes(message),
                Encoding.UTF8.GetBytes(string.Empty)
                );

            _connection.AppendToStreamAsync(stream, ExpectedVersion.Any, @event).Wait();
        }
    }
}
