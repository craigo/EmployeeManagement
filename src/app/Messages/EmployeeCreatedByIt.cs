using System;
using NServiceBus;

namespace Messages
{
    public class EmployeeCreatedByIt : IMessage
    {
        public Guid OriginalMessageId { get; set; }
    }
}