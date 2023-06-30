namespace rabbitmqopenapi.Messaging
{
    public class QueueMessage : IMessage
    {
        private string Text;
        public string GetText()
        {
            return Text;
        }

        public QueueMessage(string message)
        {
            this.Text = message;
        }
    }
}