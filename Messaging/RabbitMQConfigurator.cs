using RabbitMQ.Client;

namespace rabbitmqopenapi.Messaging
{
    public class RabbitMQConfigurator
    {
        public ISender<IMessage> Sender {get;}

        public IConsumer<IMessage> Consumer {get;}
        public IModel Channel {get;}

        public RabbitMQConfigurator()
        {
            this.Channel = CreateChannel();
            this.Sender = new RabbitMQSender<QueueMessage>(Channel);
            this.Consumer = new RabbitMQConsumer<QueueMessage>(Channel); 
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