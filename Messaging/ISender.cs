namespace rabbitmqopenapi.RabbitMQ
{
    interface ISender<T> where T : IMessage
    {
        string send(T t);
    }
}