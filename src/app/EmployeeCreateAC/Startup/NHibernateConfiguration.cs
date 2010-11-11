using EmployeeCreateAC.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EmployeeCreateAC.Startup
{
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
                                             x.SetProperty("current_session_context_class", typeof (SessionContext).AssemblyQualifiedName);
                                         })
                .BuildConfiguration();
            SessionFactory = configuration
                .BuildSessionFactory();

            IOC.GetImplementationOf<ISessionFactoryRegistration>().Register(SessionFactoryKeys.EmployeeCreateAC, SessionFactory);
        }
    }
}