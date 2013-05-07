// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerConfiguration.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The customer configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Customer
{
    using System.Data.Entity.Migrations;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;

    /// <summary>
    /// The customer configuration.
    /// </summary>
    internal sealed class CustomerConfiguration : DbMigrationsConfiguration<CustomerContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerConfiguration"/> class.
        /// </summary>
        public CustomerConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
