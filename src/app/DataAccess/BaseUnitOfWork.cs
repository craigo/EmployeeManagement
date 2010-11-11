using System;
using EmployeeCreateAC.DataAccess;

namespace DataAccess
{
    public class BaseUnitOfWork
    {
        private readonly ISessionFactoryRegistration sessionFactoryRegistration;
        private readonly string key;

        public BaseUnitOfWork(ISessionFactoryRegistration sessionFactoryRegistration, string key)
        {
            this.sessionFactoryRegistration = sessionFactoryRegistration;
            this.key = key;
        }

        public IUnitOfWorkScope Start()
        {
            return GetCurrentScope();
        }

        private IUnitOfWorkScope GetCurrentScope()
        {
            try
            {
                return new NHibernateUnitOfWorkScope(sessionFactoryRegistration.SessionFactory(key));
            }
            catch (InvalidOperationException)
            {
                return new NullUnitOfWorkScope();
            }
        }
    }
}