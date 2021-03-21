using Microsoft.VisualStudio.TestTools.UnitTesting;
using rabbitmqopenapi.Messaging;
using rabbitmqopenapi.Messaging.Sender;

namespace rabbitmqopenapi.MessagingTests
{
    [TestClass]
    public class MessagingUnitTests
    {
        [TestMethod]
        public void Should_Send_Simple_Message()
        {
            RabbitMQConfigurator rabbitMQConfigurator = new Messaging.Sender.RabbitMQConfigurator();
            ISender<IMessage> Sender = new RabbitMQSender<IMessage>(rabbitMQConfigurator.GetModel());

            string message = "Hello World! From Ernst";
            var s = Sender.send(new QueueMessage(message));
            Assert.AreEqual(" [x] Sent " + message, s);
        }
    }
}
