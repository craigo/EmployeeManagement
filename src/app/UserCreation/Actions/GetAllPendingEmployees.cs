using System.Collections.Generic;
using UserCreation.Repositories;

namespace UserCreation.Actions
{
    public class GetAllPendingEmployees : ICommand
    {
        private readonly IPendingEmployeeRepository pendingEmployeeRepository = new PendingEmployeeRepository();

        public IEnumerable<PendingEmployeeDisplay> Execute()
        {
            using (UnitOfWork.Start())
            {
                return pendingEmployeeRepository.GetAllForDisplay();
            }
        }
    }
}