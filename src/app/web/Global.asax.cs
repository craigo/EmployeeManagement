using System;
using System.Web.Mvc;
using System.Web.Routing;
using Messages;
using NServiceBus;
using NServiceBus.ObjectBuilder;
using NServiceBus.Unicast.Transport.Msmq;

namespace web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterRoutes(RouteTable.Routes);
            ConfigureNServiceBus();
        }

        private void ConfigureNServiceBus()
        {
            var configure = Configure.WithWeb().SpringFrameworkBuilder().XmlSerializer();
            configure.Configurer
                .ConfigureComponent<MsmqTransport>(ComponentCallModelEnum.Singleton)
                .ConfigureProperty(x => x.MaxRetries, 5)
                .ConfigureProperty(x => x.PurgeOnStartup, false)
                .ConfigureProperty(x => x.InputQueue, "EmployeeCreationInputQueue")
                .ConfigureProperty(x => x.ErrorQueue, "error");
            CreatedBus.Bus = configure
                .UnicastBus()
                .ForwardReceivedMessagesTo(string.Empty)
                .ImpersonateSender(false)
                .CreateBus()
                .Start();
        }
    }
}