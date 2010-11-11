using NServiceBus;

namespace EmployeeCreateAC.Startup
{
    public class EmployeeCreateStartUp : IWantToRunAtStartup
    {
        public void Run()
        {
            NHibernateConfiguration.Configure();
        }

        public void Stop()
        {
        }
    }
}