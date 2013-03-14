namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Security
{
    using System.Data.Entity.Migrations;

    internal sealed class SecurityConfiguration : DbMigrationsConfiguration<SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.SecurityContext>
    {
        public SecurityConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts.SecurityContext context)
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
