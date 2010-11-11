using System.Collections.Generic;
using System.Linq;
using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace UserCreation.Repositories
{
    class PendingEmployeeRepository : NHibernateRepository, IPendingEmployeeRepository
    {
        public PendingEmployeeRepository() : base(UnitOfWork.SessionFactoryRegistration, SessionFactoryKeys.Web)
        {}

        public IEnumerable<PendingEmployeeDisplay> GetAllForDisplay()
        {
            var list = Session.CreateSQLQuery("select FirstName, LastName from PossibleEmployee").List();
            return from object[] item in list select new PendingEmployeeDisplay{FirstName = (string)item[0], LastName = (string) item[1]};
        }
    }
}