// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The person data service.
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
    /// The person data service.
    /// </summary>
    public class PersonDataService : IDataService
    {
        /// <summary>
        /// Creates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Create(IDomainObject obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (person.ObjectId == default(Guid))
            {
                person.ObjectId = Guid.NewGuid();
            }

            person.CreationTimeStamp = DateTime.Now;
            person.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.Persons.Add(person);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>
        /// The persons.
        /// </returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Persons.ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>
        /// The person.
        /// </returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Persons.Single(p => p.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var person = obj as Person;
            if (person == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readPerson = db.Persons.Single(p => p.ObjectId.Equals(person.ObjectId));
                readPerson.Address = person.Address;
                readPerson.EMailAddresses = person.EMailAddresses;
                readPerson.Employer = person.Employer;
                readPerson.FirstName = person.FirstName;
                readPerson.LastName = person.LastName;
                readPerson.PhoneNumbers = person.PhoneNumbers;
                readPerson.LastUpdateTimeStamp = DateTime.Now;
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
                db.Persons.Remove(this.Read(objectId) as Person);
                db.SaveChanges();
            }
        }
    }
}