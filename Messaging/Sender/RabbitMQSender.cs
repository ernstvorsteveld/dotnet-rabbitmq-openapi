using System;
using RabbitMQ.Client;
using System.Text;

namespace rabbitmqopenapi.RabbitMQ.Sender
{
    class RabbitMQSender<QueueMessage> : ISender<IMessage>
    {
        private IModel Channel;

        public RabbitMQSender(IModel channel)
        {
            this.Channel = channel;
        }

        public string send(IMessage message)
        {
            var body = Encoding.UTF8.GetBytes(message.GetText());
            Channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
            Console.WriteLine(" [x] Sent {0}", message.GetText());
            return " [x] Sent " + message.GetText();
        }
    }
}