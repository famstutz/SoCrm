// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The user map.
    /// </summary>
    public class UserMap : DomainObjectMap<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMap"/> class.
        /// </summary>
        public UserMap()
        {
            this.Table("Users");

            this.Map(x => x.UserName);
            this.Map(x => x.Role).CustomType<Role>();
            this.Map(x => x.Password);
        }
    }
}