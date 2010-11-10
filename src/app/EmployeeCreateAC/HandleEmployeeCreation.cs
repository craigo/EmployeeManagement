using Messages;
using NServiceBus;

namespace EmployeeCreateAC
{
    public class HandleEmployeeCreation : IHandleMessages<AddEmployeeMessage>
    {
        private readonly IPossibleEmployeeRepository possibleEmployeeRepository;

        public HandleEmployeeCreation(IPossibleEmployeeRepository possibleEmployeeRepository)
        {
            this.possibleEmployeeRepository = possibleEmployeeRepository;
        }

        public void Handle(AddEmployeeMessage message)
        {
            var possibleEmployee = new PossibleEmployee{FirstName = message.FirstName, LastName = message.LastName};
            using(UnitOfWork.Start())
            {
                possibleEmployeeRepository.Save(possibleEmployee);
            }
        }
    }
}