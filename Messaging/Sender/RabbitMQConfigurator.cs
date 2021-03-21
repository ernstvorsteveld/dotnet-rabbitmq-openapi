using RabbitMQ.Client;

namespace rabbitmqopenapi.RabbitMQ.Sender
{
    class RabbitMQConfigurator
    {
        private ISender<IMessage> Sender;
        private IModel Channel;
        public ISender<IMessage> ISender { get; }

        public RabbitMQConfigurator()
        {
            this.Channel = CreateChannel();
            this.Sender = new RabbitMQSender<QueueMessage>(Channel);
        }

        private IModel CreateChannel()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
            return channel;
        }
    }
}