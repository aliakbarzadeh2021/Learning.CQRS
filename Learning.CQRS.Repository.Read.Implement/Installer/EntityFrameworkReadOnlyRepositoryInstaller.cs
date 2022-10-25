namespace Learning.CQRS.Repository.Read.Implement.Installer
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Read.Context.Interfaces;
    using Context.Implements;
    public class EntityFrameworkReadOnlyRepositoryInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IReadOnlyRepository<>)).ImplementedBy(typeof(ReadOnlyRepository<>)).LifestyleTransient());

            ReadOnlyDataContext.ExecuteMigration();
        }
    }
}
