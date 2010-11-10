using Castle.Windsor;
using NServiceBus;

namespace EmployeeCreateAC
{
    public class Endpoint : IConfigureThisEndpoint, AsA_Server, IWantCustomInitialization
    {
        private static WindsorContainer _container;

        public void Init()
        {
            _container = new WindsorContainer();
            Configure.With()
                .CastleWindsorBuilder(_container)
                .XmlSerializer();
            WindsorStartup.Configure(_container);
        }
    }
}