namespace rabbitmqopenapi.Messaging
{
    public interface ISender<T> where T : IMessage
    {
        string send(T t);
    }
}