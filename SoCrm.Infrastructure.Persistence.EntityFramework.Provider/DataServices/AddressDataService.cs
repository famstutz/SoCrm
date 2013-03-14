using System;
using System.Collections.Generic;
using System.Linq;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    public class AddressDataService : IDataService
    {
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

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Addresses.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Addresses.Single(a => a.ObjectId.Equals(objectId));
            }
        }

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