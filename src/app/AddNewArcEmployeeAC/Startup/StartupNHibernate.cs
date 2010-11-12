using EmployeeCreateAC.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace AddNewArcEmployeeAC.Startup
{
    public static class StartupNHibernate
    {
        public static ISessionFactory SessionFactory { get; set; }

        public static ISessionFactoryRegistration SessionFactoryRegistration { get; private set; }

        public static void Configure()
        {
            var configuration = Fluently.Configure()
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Endpoint>())
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

            SessionFactoryRegistration = new SessionFactoryRegistration();
            SessionFactoryRegistration.Register(SessionFactoryKeys.AddNewArcEmployeeAC, SessionFactory);
        }
    }
}