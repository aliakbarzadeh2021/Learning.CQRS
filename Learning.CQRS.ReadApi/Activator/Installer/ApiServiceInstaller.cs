using System;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.QueryService.Implement.Installer;
using Learning.CQRS.ReadApi.Activator.SeedWorks.Core;
using Learning.CQRS.Infrastructure.Configuration;

namespace Learning.CQRS.ReadApi.Activator.Installer
{
    public class ApiServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            try
            {
                ApplicationSettingsFactory.InitializeApplicationSettingsFactory(new AppConfigApplicationSettings());

                container.Install(new QueryServiceInstaller());
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
