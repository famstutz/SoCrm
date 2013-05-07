// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EMailAddressDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The email address data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The email address data service.
    /// </summary>
    public class EMailAddressDataService : IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// The object id.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public Guid Create(IDomainObject obj)
        {
            var emailAddress = obj as EMailAddress;
            if (emailAddress == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (emailAddress.ObjectId == default(Guid))
            {
                emailAddress.ObjectId = Guid.NewGuid();
            }

            emailAddress.CreationTimeStamp = DateTime.Now;
            emailAddress.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.EMailAddresses.Add(emailAddress);
                db.SaveChanges();
            }

            return emailAddress.ObjectId;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>The email addresses.</returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.EMailAddresses.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The email address.</returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.EMailAddresses.Single(ema => ema.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var emailAddress = obj as EMailAddress;
            if (emailAddress == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readEMailAddress = db.EMailAddresses.Single(ema => ema.ObjectId.Equals(emailAddress.ObjectId));
                readEMailAddress.Address = emailAddress.Address;
                readEMailAddress.ContactType = emailAddress.ContactType;
                readEMailAddress.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        public void Delete(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                var emailAddress = this.Read(objectId) as EMailAddress;
                db.EMailAddresses.Attach(emailAddress);
                db.EMailAddresses.Remove(emailAddress);
                db.SaveChanges();
            }
        }
    }
}