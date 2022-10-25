using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.Handler.Installer;
using Learning.CQRS.WriteApi.Activator.BusConfig;
using Learning.CQRS.WriteApi.Activator.SeedWorks.Core;
using Learning.CQRS.Infrastructure.Configuration;

namespace Learning.CQRS.WriteApi.Activator.Installer
{
    public class ApiServiceInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            try
            {
                ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new AppConfigApplicationSettings());
                BusConfiguratorService.Configure();
                container.Install(new CommandHandlerInstaller());
                //  ICommandBus
                container.Register(Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleTransient());
                container.Register(Classes.FromThisAssembly().BasedOn<ApiControllerBase>().LifestyleTransient());
                container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel, true));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
