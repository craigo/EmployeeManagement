using System;
using Castle.Windsor;

namespace EmployeeCreateAC
{
    static public class IOC
    {
        private static WindsorContainer IOCInstance;

        public static void Register(WindsorContainer container)
        {
            IOCInstance = container;
        }

        public static T GetImplementationOf<T>()
        {
            AssertContainerInitialized();
            return IOCInstance.Resolve<T>();
        }

        public static void ClearImplementations()
        {
            IOCInstance = null;
        }

        private static void AssertContainerInitialized()
        {
            if (IOCInstance == null)
            {
                throw new InvalidOperationException("IOC not initialized. Call IOC.Register(IDependencyResolver resolver).");
            }
        }
    }
}