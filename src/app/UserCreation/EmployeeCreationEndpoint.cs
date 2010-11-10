using Messages;
using NServiceBus;
using NServiceBus.ObjectBuilder;
using NServiceBus.Unicast.Transport.Msmq;

namespace UserCreation
{
    public class EmployeeCreationEndpoint : IWantToRunAtStartup, AsA_Publisher
    {
        public IBus Bus { get; set; }

        public void Run()
        {
            var configure = Configure.WithWeb();
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

        public void Stop()
        {
        }
    }
}