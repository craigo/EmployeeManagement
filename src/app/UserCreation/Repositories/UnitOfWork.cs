using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace UserCreation.Repositories
{
    public static class UnitOfWork
    {
        public static readonly ISessionFactoryRegistration SessionFactoryRegistration = new SessionFactoryRegistration();
        private static BaseUnitOfWork UOW = new BaseUnitOfWork(SessionFactoryRegistration, SessionFactoryKeys.Web);

        public static IUnitOfWorkScope Start()
        {
            return UOW.Start();
        }
    }
}