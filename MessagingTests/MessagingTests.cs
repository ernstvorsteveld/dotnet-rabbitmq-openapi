using Microsoft.VisualStudio.TestTools.UnitTesting;
using rabbitmqopenapi.Messaging;

namespace rabbitmqopenapi.MessagingTests
{
    [TestClass]
    public class MessagingUnitTests
    {
        static string ConsumerFunction(IMessage message)
        {
            return message.GetText();
        }

        RabbitMQConfigurator rabbitMQConfigurator = new Messaging.RabbitMQConfigurator();

        [TestMethod]
        public void Should_Send_Simple_Message()
        {
            string message = "Hello World! From Mr. Bean.";
            string expected = " [x] Sent " + message;
            Assert.AreEqual(expected, rabbitMQConfigurator.Sender.send(new QueueMessage(message)));
            Assert.AreEqual(expected, rabbitMQConfigurator.Consumer.consume(ConsumerFunction));
        }
    }
}
