using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.Repository.SeedWorks;
using Learning.CQRS.Infrastructure.Configuration;
using Learning.CQRS.Repository.Read.Implement.Installer;

namespace Learning.CQRS.QueryService.Implement.Installer
{
    public class QueryServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            DataProviderConfigurator.AddMappingFromAssemblyOf<MappingAssembelyFinder>();
            container.Install(new EntityFrameworkReadOnlyRepositoryInstaller());
            container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().Pick().WithServiceDefaultInterfaces().LifestyleTransient());
            ActiveMapper.Initialize();
        }
    }
}
