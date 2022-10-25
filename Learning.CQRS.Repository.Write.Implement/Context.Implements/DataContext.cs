using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Learning.CQRS.Infrastructure.Configuration;
using Learning.CQRS.Repository.Write.Context.Interfaces;
using Learning.CQRS.Repository.Write.Implement.Exceptions;
using Learning.CQRS.Repository.Write.Implement.Helpers;
using Learning.CQRS.Repository.Write.Implement.Migrations;

namespace Learning.CQRS.Repository.Write.Implement.Context.Implements
{
    public class DataContext : DbContext, IContext
    {

        public DataContext() : base(ApplicationSettingsFactory.GetApplicationSettings().SqlConnectionString)
        {
            Initialize();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            if (!DataProviderConfigurator.IsConfigured)
                throw new DataProviderAssembliesNotFoundException();

            //Register FluentMappings
            Array.ForEach(DataProviderConfigurator.MappingAssemblies.ToArray(), modelBuilder.AddMappingsFromAssemblyOf);

        }


        private void Initialize()
        {
            //IDataContext
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Database.CommandTimeout = 100000;

            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Configuration>());
            //CompositeDatabaseInitializer<DataContext<TDataTable>> compositeDatabaseInitializer = new CompositeDatabaseInitializer<DataContext<TDataTable>>(new MigrateDatabaseToLatestVersion<DataContext<TDataTable>, Migrations.Configuration<TDataTable>>(), new IndexInitializer<DataContext<TDataTable>>());
            //Database.SetInitializer(compositeDatabaseInitializer);

        }


        public static void ExecuteMigration()
        {
            try
            {
                DataContext dx = new DataContext();
                dx.Database.Initialize(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }


        public void Dispose()
        {
            // base.Dispose();
        }
    }

}
