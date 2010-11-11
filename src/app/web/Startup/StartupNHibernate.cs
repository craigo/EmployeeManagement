using EmployeeCreateAC.DataAccess;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using UserCreation.Repositories;
using web.Controllers;

namespace web.Startup
{
    public static class StartupNHibernate
    {
        public static void Configure()
        {
            var configuration = Fluently.Configure()
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<HomeController>())
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

            UnitOfWork.SessionFactoryRegistration.Register(SessionFactoryKeys.Web, SessionFactory);
        }

        public static ISessionFactory SessionFactory { get; set; }
    }
}