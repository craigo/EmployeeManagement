using Messages;
using NServiceBus;
using NServiceBus.ObjectBuilder;
using NServiceBus.Unicast.Transport.Msmq;

namespace web.Startup
{
    public class StartupNServiceBus
    {
        public static void Configure()
        {
            var configure = NServiceBus.Configure.WithWeb().SpringFrameworkBuilder().XmlSerializer();
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