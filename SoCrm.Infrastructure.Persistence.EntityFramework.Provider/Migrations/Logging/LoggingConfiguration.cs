namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Logging
{
    using System.Data.Entity.Migrations;

    internal sealed class LoggingConfiguration : DbMigrationsConfiguration<SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.LoggingContext>
    {
        public LoggingConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.LoggingContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
