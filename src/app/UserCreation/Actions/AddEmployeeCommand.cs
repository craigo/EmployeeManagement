using NServiceBus;

namespace UserCreation.Actions
{
    public interface IPublishAMessage
    {
        void Execute(IMessage messageToPublish);
    }

    public class AddEmployeeAMessage : IPublishAMessage
    {
        public void Execute(IMessage messageToPublish)
        {
            CreatedBus.Bus.Publish(messageToPublish);
        }
    }
}