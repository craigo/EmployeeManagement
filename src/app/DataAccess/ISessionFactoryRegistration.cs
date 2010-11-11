using NHibernate;

namespace EmployeeCreateAC.DataAccess
{
    public interface ISessionFactoryRegistration
    {
        void Register(string key, ISessionFactory sessionFactory);
        ISessionFactory SessionFactory(string key);
    }
}