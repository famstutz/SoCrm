// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The address data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    /// <summary>
    /// The address data service.
    /// </summary>
    public class AddressDataService : IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Create(IDomainObject obj)
        {
            var address = obj as Address;
            if (address == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (address.ObjectId == default(Guid))
            {
                address.ObjectId = Guid.NewGuid();
            }

            address.CreationTimeStamp = DateTime.Now;
            address.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.Addresses.Add(address);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>The addresses.</returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Addresses.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The address.</returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Addresses.Single(a => a.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var address = obj as Address;
            if (address == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readAddress = db.Addresses.Single(a => a.ObjectId.Equals(address.ObjectId));
                readAddress.AddressLine = address.AddressLine;
                readAddress.ZipCode = address.ZipCode;
                readAddress.City = address.City;
                readAddress.Country = address.Country;
                readAddress.LastUpdateTimeStamp = DateTime.Now;
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
                db.Addresses.Remove(this.Read(objectId) as Address);
                db.SaveChanges();
            }
        }
    }
}