using NServiceBus;

namespace Messages
{
    public interface IEmployeeMessage : IMessage
    {
        int MessageId { get; set; }
    }
}