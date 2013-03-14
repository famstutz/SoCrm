using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    public class PhoneNumberDataService : IDataService
    {
        public void Create(IDomainObject obj)
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
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.PhoneNumbers.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.PhoneNumbers.Single(pn => pn.ObjectId.Equals(objectId));
            }
        }

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

        public void Delete(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                db.PhoneNumbers.Remove(this.Read(objectId) as PhoneNumber);
                db.SaveChanges();
            }
        }
    }
}