// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The person data service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.EntityFramework.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Core.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Contexts;
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
        /// <returns>
        /// The object id.
        /// </returns>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public Guid Create(IDomainObject obj)
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

            if (person.Address != null)
            {
                if (person.Address.ObjectId == default(Guid))
                {
                    person.Address.ObjectId = Guid.NewGuid();
                }

                person.Address.CreationTimeStamp = DateTime.Now;
                person.Address.LastUpdateTimeStamp = DateTime.Now;
            }

            using (var db = new CustomerContext())
            {
                if (person.Employer != null)
                {
                    db.Companies.Attach(person.Employer);
                }

                if (person.EMailAddresses != null)
                {
                    foreach (var emailAddress in person.EMailAddresses)
                    {
                        db.EMailAddresses.Attach(emailAddress);
                    }
                }

                if (person.PhoneNumbers != null)
                {
                    foreach (var phoneNumber in person.PhoneNumbers)
                    {
                        db.PhoneNumbers.Attach(phoneNumber);
                    }
                }

                db.Persons.Add(person);
                db.SaveChanges();
            }

            return person.ObjectId;
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
                return db.Persons.Include("Employer").Include("Address").Include("EMailAddresses").Include("PhoneNumbers").ToList();
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
                return db.Persons.Include("Employer").Include("Address").Include("EMailAddresses").Include("PhoneNumbers").Single(p => p.ObjectId.Equals(objectId));
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
                var readPerson = db.Persons.Include("Employer").Include("Address").Include("EMailAddresses").Include("PhoneNumbers").Single(p => p.ObjectId.Equals(person.ObjectId));
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
                var person = this.Read(objectId) as Person;
                db.Persons.Attach(person);
                db.Persons.Remove(person);
                db.SaveChanges();
            }
        }
    }
}