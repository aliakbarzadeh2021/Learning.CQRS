using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Learning.CQRS.DomainModel.Events;

namespace Learning.CQRS.Domain.Installer
{
    public class DomainModelInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().Pick().WithServiceDefaultInterfaces().LifestyleTransient());

            //container.Register(Classes.FromThisAssembly().IncludeNonPublicTypes().BasedOn<DomainEventHandler>().WithServiceAllInterfaces());

            if (!container.Kernel.HasComponent(typeof(IDomainEventHandlerFactory)))
                container.Register(Component.For<IDomainEventHandlerFactory>().ImplementedBy<DomainEventHandlerFactory>());
        }
    }
}
