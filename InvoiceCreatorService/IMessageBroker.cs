namespace Infrastructure
{
    public interface IMessageBroker
    {
        T Read<T>(int eventNumber)
            where T : class;
        void Write<T>(T message);
    }
}
