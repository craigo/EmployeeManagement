using NHibernate;

namespace EmployeeCreateAC
{
    public interface IPossibleEmployeeRepository
    {
        void Save(PossibleEmployee possibleEmployee);
    }

    public class PossibleEmployeeRepository : IPossibleEmployeeRepository
    {
        private readonly ISessionFactoryRegistration sessionFactoryRegistration;

        public PossibleEmployeeRepository(ISessionFactoryRegistration sessionFactoryRegistration)
        {
            this.sessionFactoryRegistration = sessionFactoryRegistration;
        }

        private ISession Session
        {
            get { return sessionFactoryRegistration.SessionFactory().GetCurrentSession(); }
        }

        public void Save(PossibleEmployee possibleEmployee)
        {
            Session.Save(possibleEmployee);
        }
    }
}