using System.Collections.Generic;

namespace UserCreation.Repositories
{
    public interface IPendingEmployeeRepository
    {
        IEnumerable<PendingEmployeeDisplay> GetAllForDisplay();
    }
}