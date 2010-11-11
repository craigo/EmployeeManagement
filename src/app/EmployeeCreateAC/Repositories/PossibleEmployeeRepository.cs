using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace EmployeeCreateAC.Repositories
{
    public class PossibleEmployeeRepository : NHibernateRepository, IPossibleEmployeeRepository
    {
        public PossibleEmployeeRepository(ISessionFactoryRegistration sessionFactoryRegistration) : base(sessionFactoryRegistration, SessionFactoryKeys.EmployeeCreateAC)
        {}

        public void Save(PossibleEmployee possibleEmployee)
        {
            Session.Save(possibleEmployee);
        }
    }
}