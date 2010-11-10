using NServiceBus;

namespace Messages
{
    public class CreatedBus
    {
        public static IBus Bus { get; set; }
    }
}