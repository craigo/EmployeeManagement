using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EmployeeCreateAC.DataAccess;
using EmployeeCreateAC.Repositories;

namespace EmployeeCreateAC.Startup
{
    public static class WindsorStartup
    {
        public static WindsorContainer Container;

        public static void Configure()
        {
            Configure(new WindsorContainer());
        }

        private static void RegisterIn(WindsorContainer container)
        {
            container.Register(Component.For<IPossibleEmployeeRepository>().ImplementedBy<PossibleEmployeeRepository>());
            container.Register(Component.For<ISessionFactoryRegistration>().ImplementedBy<SessionFactoryRegistration>());
            container.Register(Component.For<IUnitOfWorkScope>().ImplementedBy<NHibernateUnitOfWorkScope>());
        }

        public static void Configure(WindsorContainer container)
        {
            Container = container;
            RegisterIn(Container);
            IOC.Register(Container);
        }
    }
}