using Castle.Windsor;
using Learning.CQRS.ReadApi.Activator.Installer;

namespace Learning.CQRS.ReadApi.Activator
{
    public class Bootstrapper
    {
        static Bootstrapper()
        {
            Container = new WindsorContainer();
        }

        public static IWindsorContainer Container
        {
            get;
            private set;
        }

        public static void Run()
        {
            Container.Install(new ApiServiceInstaller());
        }

        public static void ShutDown()
        {
            if (Container != null)
                Container.Dispose();
        }
    }
}
