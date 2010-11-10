using Messages;
using NServiceBus;

namespace EmployeeCreateAC
{
    public class HandleEmployeeCreation : IHandleMessages<AddEmployeeMessage>
    {
        public void Handle(AddEmployeeMessage message)
        {
            System.Console.WriteLine("received add employee message.");
        }
    }
}