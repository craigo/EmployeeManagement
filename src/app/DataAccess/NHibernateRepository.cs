using EmployeeCreateAC.DataAccess;
using NHibernate;

namespace DataAccess
{
    public abstract class NHibernateRepository
    {
        private readonly ISessionFactoryRegistration sessionFactoryRegistration;
        private readonly string key;

        protected NHibernateRepository(ISessionFactoryRegistration sessionFactoryRegistration, string key)
        {
            this.sessionFactoryRegistration = sessionFactoryRegistration;
            this.key = key;
        }

        protected ISession Session
        {
            get { return sessionFactoryRegistration.SessionFactory(key).GetCurrentSession(); }
        }

    }
}