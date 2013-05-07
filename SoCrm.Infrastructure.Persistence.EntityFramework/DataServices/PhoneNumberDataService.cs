// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneNumberDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The phone number data service.
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
    /// The phone number data service.
    /// </summary>
    public class PhoneNumberDataService : IDataService
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
            var phoneNumber = obj as PhoneNumber;
            if (phoneNumber == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (phoneNumber.ObjectId == default(Guid))
            {
                phoneNumber.ObjectId = Guid.NewGuid();
            }

            phoneNumber.CreationTimeStamp = DateTime.Now;
            phoneNumber.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.PhoneNumbers.Add(phoneNumber);
                db.SaveChanges();
            }

            return phoneNumber.ObjectId;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// The phone numbers.
        /// </returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.PhoneNumbers.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The phone number.
        /// </returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.PhoneNumbers.Single(pn => pn.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var phoneNumber = obj as PhoneNumber;
            if (phoneNumber == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readPhoneNumber = db.PhoneNumbers.Single(pn => pn.ObjectId.Equals(phoneNumber.ObjectId));
                readPhoneNumber.Number = phoneNumber.Number;
                readPhoneNumber.ContactType = phoneNumber.ContactType;
                readPhoneNumber.LastUpdateTimeStamp = DateTime.Now;
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
                var phoneNumber = this.Read(objectId) as PhoneNumber;
                db.PhoneNumbers.Attach(phoneNumber);
                db.PhoneNumbers.Remove(phoneNumber);
                db.SaveChanges();
            }
        }
    }
}