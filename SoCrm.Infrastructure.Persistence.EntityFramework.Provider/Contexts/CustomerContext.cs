// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerContext.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The customer context.
    /// </summary>
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerContext"/> class.
        /// </summary>
        public CustomerContext()
            : base("Name=Customer")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Gets or sets the persons.
        /// </summary>
        /// <value>
        /// The persons.
        /// </value>
        public DbSet<Person> Persons { get; set; }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        /// <summary>
        /// Gets or sets the addresses.
        /// </summary>
        /// <value>
        /// The addresses.
        /// </value>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the E mail addresses.
        /// </summary>
        /// <value>
        /// The E mail addresses.
        /// </value>
        public DbSet<EMailAddress> EMailAddresses { get; set; }
    }
}