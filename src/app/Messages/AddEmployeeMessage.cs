using System;

namespace Messages
{
    [Serializable]
    public class AddEmployeeMessage : IEmployeeMessage
    {
        public int MessageId { get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}