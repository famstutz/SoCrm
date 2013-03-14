using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    public class PersonDataService : IDataService
    {
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

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Persons.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Persons.Single(p => p.ObjectId.Equals(objectId));
            }
        }

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