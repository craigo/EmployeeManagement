using Messages;

namespace UserCreation.Actions
{
    public class SignOnEmployee : ICommand
    {
        public virtual void Execute(int newEmployeeId)
        {
            CreatedBus.Bus.Publish(new CreateSignedOnEmployee{EmployeeId = newEmployeeId});
        }
    }
}