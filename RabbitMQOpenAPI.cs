namespace rabbitmqopenapi
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
                           .AddFilter("LoggingConsoleApp.Program", LogLevel.Debug)
                           .AddConsole()
                           .AddEventLog();
                   });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            logger.LogInformation("Example log message");
        }
    }
}