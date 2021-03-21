using System;
using Microsoft.Extensions.Logging;

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
        }
    }
}