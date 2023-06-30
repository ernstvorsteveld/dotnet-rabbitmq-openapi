using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace rabbitmqopenapi.Messaging
{
    public class RabbitMQConsumer<QueueMessage> : IConsumer<IMessage>
    {
        private IModel Channel;

        public RabbitMQConsumer(IModel channel)
        {
            this.Channel = channel;
        }

        public string consume(Func<IMessage, string> handler)
        {
            var consumer = new EventingBasicConsumer(Channel);
            rabbitmqopenapi.Messaging.QueueMessage message;
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                message = new rabbitmqopenapi.Messaging.QueueMessage(Encoding.UTF8.GetString(body));
                Console.WriteLine(" [x] Received {0}", message.GetText());
            };
            return handler(message);
        }
    }
}