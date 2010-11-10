using NHibernate;

namespace EmployeeCreateAC
{
    public interface IPossibleEmployeeRepository
    {
        void Save(PossibleEmployee possibleEmployee);
    }

    public class PossibleEmployeeRepository : IPossibleEmployeeRepository
    {
        private ISession Session { get; set; }

        public void Save(PossibleEmployee possibleEmployee)
        {
            Session.Save(possibleEmployee);
        }
    }
}