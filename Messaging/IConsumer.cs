using System;

namespace rabbitmqopenapi.Messaging
{
    public interface IConsumer<T> where T : IMessage
    {
        string consume(Func<T, string> handler);
    }
}