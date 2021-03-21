namespace rabbitmqopenapi.Messaging
{
    public class QueueMessage : IMessage
    {
        private string Text;

        string IMessage.GetText()
        {
            return this.Text;
        }

        public QueueMessage(string message)
        {
            this.Text = message;
        }
    }
}