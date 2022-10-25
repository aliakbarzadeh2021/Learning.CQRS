using System.Data.Entity.Migrations;
using Learning.CQRS.Repository.Read.Implement.Context.Implements;

namespace Learning.CQRS.Repository.Read.Implement.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ReadOnlyDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;

            //ContextKey = this.GetType().Namespace;
        }

        protected override void Seed(ReadOnlyDataContext context)
        {

        }
    }
}
