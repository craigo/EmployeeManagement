using NServiceBus;

namespace AddNewArcEmployeeAC.Startup
{
    public class AddNewArcEmployeeACStartUp : IWantToRunAtStartup
    {
        public void Run()
        {
            StartupNHibernate.Configure();
        }

        public void Stop()
        {
        }
    }
}