using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using Learning.CQRS.Infrastructure.Configuration;
using Learning.CQRS.Repository.Read.Implement.Exceptions;
using Learning.CQRS.Repository.Read.Implement.Helpers;

namespace Learning.CQRS.Repository.Read.Implement.Context.Implements
{
    internal class ReadOnlyDataContext : DbContext
    {

        public ReadOnlyDataContext() : base(ApplicationSettingsFactory.GetApplicationSettings().SqlConnectionString)
        {
            Initialize();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();


            if (!DataProviderConfigurator.IsConfigured)
                throw new DataProviderAssembliesNotFoundException();

            //Register FluentMappings
            Array.ForEach(DataProviderConfigurator.MappingAssemblies.ToArray(), modelBuilder.AddMappingsFromAssemblyOf);


        }

        private void Initialize()
        {
            //IReadOnlyContext
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;

            Database.SetInitializer(new NullDatabaseInitializer<ReadOnlyDataContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<DataContext<TDataTable>>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ReadOnlyDataContext, Migrations.Configuration>());
            //CompositeDatabaseInitializer<DataContext<TDataTable>> compositeDatabaseInitializer = new CompositeDatabaseInitializer<DataContext<TDataTable>>(new MigrateDatabaseToLatestVersion<DataContext<TDataTable>, Migrations.Configuration<TDataTable>>(), new IndexInitializer<DataContext<TDataTable>>());
            //Database.SetInitializer(compositeDatabaseInitializer);

        }

        public IQueryable<TDto> SqlQuery<TDto>(string storedProcedure, Dictionary<string, object> parameteres) where TDto : class
        {
            if (parameteres != null && parameteres.Count > 0)
            {
                object[] sqlParameters = new SqlParameter[parameteres.Count];
                int index = 0;
                foreach (var parametere in parameteres)
                {
                    SqlParameter sqlParameter = new SqlParameter(parametere.Key, parametere.Value);
                    sqlParameters[index] = sqlParameter;
                    index++;
                }
                return Database.SqlQuery<TDto>(storedProcedure, sqlParameters).AsQueryable();
            }

            return Database.SqlQuery<TDto>(storedProcedure).AsQueryable();
        }



        public static void ExecuteMigration()
        {
            try
            {
                ReadOnlyDataContext dx = new ReadOnlyDataContext();
                dx.Database.Initialize(true);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
    }
}
