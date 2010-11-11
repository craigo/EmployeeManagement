using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace EmployeeCreateAC.Repositories
{
    public static class UnitOfWork
    {
        private static readonly BaseUnitOfWork UOW = new BaseUnitOfWork(IOC.GetImplementationOf<ISessionFactoryRegistration>(), SessionFactoryKeys.EmployeeCreateAC);

        public static IUnitOfWorkScope Start()
        {
            return UOW.Start();
        }
    }
}