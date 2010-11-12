using AddNewArcEmployeeAC.Startup;
using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace AddNewArcEmployeeAC.Repositories
{
    public interface IEmployeeRepository
    {
        void Add(Employee employeeToSave);
    }

    public class EmployeeRepository : NHibernateRepository, IEmployeeRepository
    {
        public EmployeeRepository() : base(StartupNHibernate.SessionFactoryRegistration, SessionFactoryKeys.AddNewArcEmployeeAC)
        {}

        public void Add(Employee employeeToSave)
        {
            using (UnitOfWork.Start())
            {
                Session.Save(employeeToSave);
            }
        }
    }
}