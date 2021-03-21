using System;
using Microsoft.Extensions.Logging;
using rabbitmqopenapi.Messaging;
using rabbitmqopenapi.Messaging.Sender;

namespace rabbitmqopenapi.console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
                   {
                       builder
                           .AddFilter("Microsoft", LogLevel.Warning)
                           .AddFilter("System", LogLevel.Warning)
                           .AddFilter("rabbitmqopenapi.console.Program", LogLevel.Debug)
                           .AddConsole();
                   });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogDebug("Example log message, Debug level.");

            RabbitMQConfigurator rabbitMQConfigurator = new Messaging.Sender.RabbitMQConfigurator();
            ISender<IMessage> Sender = new RabbitMQSender<IMessage>(rabbitMQConfigurator.GetModel());

            Sender.send(new QueueMessage("Hello World! From Ernst"));
        }
    }
}