using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.Repository.Write.Context.Interfaces;
using Learning.CQRS.Repository.Write.Implement.Context.Implements;

namespace Learning.CQRS.Repository.Write.Implement.Installer
{
    public class EntityFrameworkWriteRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                .For<IContext>()
                .ImplementedBy<DataContext>()
                //.LifestylePerWebRequest()
                .LifestyleScoped()
                //.LifestylePerThread()
                );
            container.Register(
                Component
                .For(typeof(IRepository<>))
                .ImplementedBy(typeof(Repository<>))
                //.LifestylePerWebRequest()
                .LifestyleScoped()
                //.LifestylePerThread()
                );

            DataContext.ExecuteMigration();
        }
    }
}
