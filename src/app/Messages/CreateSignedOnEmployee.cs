﻿using System;
using NServiceBus;

namespace Messages
{
    [Serializable]
    public class CreateSignedOnEmployee : IMessage
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}