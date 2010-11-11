using System;
using Messages;
using UserCreation.ViewModels;

namespace UserCreation.Actions
{
    public interface ICommand{}

    public class AddEmployeeCommand : ICommand
    {
        public virtual void Execute(NewEmployee newEmployee)
        {
            var message = new AddEmployeeMessage
                              {
                                  FirstName = newEmployee.FirstName,
                                  LastName = newEmployee.LastName,
                                  MessageId = new Random(0).Next()
                              };

            CreatedBus.Bus.Send(message);
        }
    }
}