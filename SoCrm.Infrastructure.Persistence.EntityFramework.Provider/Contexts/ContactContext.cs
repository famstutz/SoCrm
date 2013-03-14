namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactContext()
            : base("Name=Contact")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Person>();
        }
    }
}