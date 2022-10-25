using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.Repository.Write.Implement.Installer;

namespace Learning.CQRS.Repository.Installer
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Install(new EntityFrameworkWriteRepositoryInstaller());
        }
    }
}
