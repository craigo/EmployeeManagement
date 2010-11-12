using System;
using NServiceBus;

namespace AddNewArcEmployeeAC
{
    [Serializable]
    public class CreateEmployee : IMessage
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}