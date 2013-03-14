// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactConfiguration.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The contact configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Migrations.Contact
{
    using System.Data.Entity.Migrations;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;

    /// <summary>
    /// The contact configuration.
    /// </summary>
    internal sealed class ContactConfiguration : DbMigrationsConfiguration<ContactContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactConfiguration"/> class.
        /// </summary>
        public ContactConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
