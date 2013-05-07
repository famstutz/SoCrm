// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityConfiguration.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The security configuration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Migrations.Security
{
    using System.Data.Entity.Migrations;

    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;

    /// <summary>
    /// The security configuration.
    /// </summary>
    internal sealed class SecurityConfiguration : DbMigrationsConfiguration<SecurityContext>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityConfiguration"/> class.
        /// </summary>
        public SecurityConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
