namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Customers.Contracts;

    public class CustomerContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EMailAddress> EMailAddresses { get; set; }

        public CustomerContext() : base("Name=Customer") { }
    }
}