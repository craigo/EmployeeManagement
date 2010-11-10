using Messages;
using NServiceBus;

namespace EmployeeCreateAC
{
    public class HandleEmployeeCreation : IHandleMessages<AddEmployeeMessage>
    {
        public void Handle(AddEmployeeMessage message)
        {
            var possibleEmployee = new PossibleEmployee{FirstName = message.FirstName, LastName = message.LastName};
        }
    }
}