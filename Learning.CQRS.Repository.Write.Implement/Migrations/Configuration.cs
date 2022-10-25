using System.Data.Entity.Migrations;
using Learning.CQRS.Repository.Write.Implement.Context.Implements;

namespace Learning.CQRS.Repository.Write.Implement.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

            //ContextKey = this.GetType().Namespace;
        }

        protected override void Seed(DataContext context)
        {

        }
    }
}
