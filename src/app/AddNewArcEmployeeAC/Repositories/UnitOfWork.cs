using AddNewArcEmployeeAC.Startup;
using DataAccess;
using EmployeeCreateAC.DataAccess;

namespace AddNewArcEmployeeAC.Repositories
{
    public static class UnitOfWork
    {
        public static BaseUnitOfWork BaseUnitOfWork { get; set; }

        static UnitOfWork()
        {
            BaseUnitOfWork = new BaseUnitOfWork(StartupNHibernate.SessionFactoryRegistration, SessionFactoryKeys.AddNewArcEmployeeAC);
        }

        public static IUnitOfWorkScope Start()
        {
            return BaseUnitOfWork.Start();
        }
    }
}