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
            var list = Session.CreateSQLQuery("select Id, FirstName, LastName from PossibleEmployee").List();
            return from object[] item in list select new PendingEmployeeDisplay{Id = (int) item[0], FirstName = (string)item[1], LastName = (string) item[2]};
        }
    }
}