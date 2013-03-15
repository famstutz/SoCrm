// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The user data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The user data service.
    /// </summary>
    public class UserDataService : IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Create(IDomainObject obj)
        {
            var user = obj as User;
            if (user == null)
            {
                throw new NotSupportedException(string.Format("UserDataService cannot deal with supplied type"));
            }

            if (user.ObjectId == default(Guid))
            {
                user.ObjectId = Guid.NewGuid();
            }

            user.CreationTimeStamp = DateTime.Now;
            user.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new SecurityContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// The users.
        /// </returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new SecurityContext())
            {
                return db.Users.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The user.
        /// </returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new SecurityContext())
            {
                return db.Users.Single(le => le.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var user = obj as User;
            if (user == null)
            {
                throw new NotSupportedException(string.Format("UserDataService cannot deal with supplied type"));
            }

            using (var db = new SecurityContext())
            {
                var readUser = db.Users.Single(le => le.ObjectId.Equals(user.ObjectId));
                readUser.UserName = user.UserName;
                readUser.Role = user.Role;
                readUser.Password = user.Password;
                readUser.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        public void Delete(Guid objectId)
        {
            using (var db = new SecurityContext())
            {
                var user = this.Read(objectId) as User;
                db.Users.Attach(user);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}