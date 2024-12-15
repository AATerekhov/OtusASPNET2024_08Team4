namespace BroadcasterMicroservice.Domain.ValueObject
{
    public class NotificationMessage
    {
        public string Message { get; }
        public string Sender { get; private set; } = "System";
        public string Addressee { get; private set; } = string.Empty;
        public NotificationMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));
            Message = message;
        }
        public NotificationMessage(string message, string addressee): this(message)
        {
            SetAddressee(addressee);
        }
        public NotificationMessage(string message, string addressee, string sender) : this(message, addressee)
        {
            SetSender(sender);
        }

        public void SetAddressee(string addressee) 
        {
            if (string.IsNullOrWhiteSpace(addressee))
                throw new ArgumentNullException(nameof(addressee));
            Addressee = addressee;
        }
        public void SetSender(string sender) 
        {
            if (string.IsNullOrWhiteSpace(sender))
                throw new ArgumentNullException(nameof(sender));
            Sender = sender;
        }
        public override string ToString() => Message;
    }
}
