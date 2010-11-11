using System.Collections.Generic;
using NHibernate;

namespace EmployeeCreateAC.DataAccess
{
    public class SessionFactoryRegistration : ISessionFactoryRegistration
    {
        private ISessionFactory sessionFactory;
        private IDictionary<string, ISessionFactory> sessionFactories = new Dictionary<string, ISessionFactory>();

        public void Register(string key, ISessionFactory sessionFactory)
        {
            this.sessionFactory= sessionFactory;
            sessionFactories.Add(key, sessionFactory);
        }

        public ISessionFactory SessionFactory(string key)
        {
            return sessionFactories[key];
        }

        public ISession CurrentSession(string key)
        {
            var session = sessionFactories[key].GetCurrentSession();
            
            if (!session.Transaction.IsActive) session.BeginTransaction();
            return session;
        }
    }
}