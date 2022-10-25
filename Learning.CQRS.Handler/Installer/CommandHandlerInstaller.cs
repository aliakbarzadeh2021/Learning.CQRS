using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.CommandBus.Installer;
using Learning.CQRS.Infrastructure.Configuration;
using Learning.CQRS.Domain.Installer;
using Learning.CQRS.Repository.Installer;
using Learning.CQRS.Repository.SeedWorks;

namespace Learning.CQRS.Handler.Installer
{
    public class CommandHandlerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            DataProviderConfigurator.AddMappingFromAssemblyOf<MappingAssembelyFinder>();
            container.Register(Classes.FromThisAssembly().Pick().WithServiceAllInterfaces().LifestyleTransient());


            container.Install(new DomainModelInstaller());
            container.Install(new CommandBusInstaller());
            container.Install(new RepositoryInstaller());
        }
    }
}
