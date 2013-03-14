namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Security.Contracts;

    public class SecurityContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SecurityContext()
            : base("Name=Security")
        {
        }
    }
}