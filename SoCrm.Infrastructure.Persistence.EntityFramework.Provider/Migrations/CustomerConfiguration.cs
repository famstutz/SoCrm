namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class CustomerConfiguration : DbMigrationsConfiguration<SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.CustomerContext>
    {
        public CustomerConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.CustomerContext context)
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
