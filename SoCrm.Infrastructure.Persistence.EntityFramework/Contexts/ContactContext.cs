// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactContext.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact context.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Contacts.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The contact context.
    /// </summary>
    public class ContactContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactContext"/> class.
        /// </summary>
        public ContactContext()
            : base("Name=Contact")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// Gets or sets the contacts.
        /// </summary>
        /// <value>
        /// The contacts.
        /// </value>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        /// before the model has been locked down and used to initialize the context.  The default
        /// implementation of this method does nothing, but it can be overridden in a derived class
        /// such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<User>();
            modelBuilder.Ignore<Person>();
        }
    }
}