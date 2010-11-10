using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NServiceBus;

namespace EmployeeCreateAC
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

    public static class NHibernateConfiguration
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static void Configure()
        {
            var configuration = Fluently.Configure()
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<EmployeeCreateStartUp>())
                .Database(MsSqlConfiguration.MsSql2005)
                .ExposeConfiguration(x =>
                                         {
                                             x.SetProperty("connection.connection_string", "Server=(local);Database=EmployeeManagement;User Id=EmpManagement_Possible;Password=password;Trusted_Connection=False");
                                             x.SetProperty("adonet.batch_size", "500");
                                             x.SetProperty("current_session_context_class", typeof (EmployeeCreateACSessionContext).AssemblyQualifiedName);
                                         })
                .BuildConfiguration();
            SessionFactory = configuration
                .BuildSessionFactory();
        }
    }

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
        }

        public static void Configure(WindsorContainer container)
        {
            Container = container;
            RegisterIn(Container);
        }
    }
}