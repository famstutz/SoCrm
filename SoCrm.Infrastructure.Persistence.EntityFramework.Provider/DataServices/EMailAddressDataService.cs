using System;
using System.Collections.Generic;
using System.Linq;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    public class EMailAddressDataService : IDataService
    {
        public void Create(IDomainObject obj)
        {
            var eMailAddress = obj as EMailAddress;
            if (eMailAddress == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (eMailAddress.ObjectId == default(Guid))
            {
                eMailAddress.ObjectId = Guid.NewGuid();
            }

            eMailAddress.CreationTimeStamp = DateTime.Now;
            eMailAddress.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.EMailAddresses.Add(eMailAddress);
                db.SaveChanges();
            }
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.EMailAddresses.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.EMailAddresses.Single(ema => ema.ObjectId.Equals(objectId));
            }
        }

        public void Update(IDomainObject obj)
        {
            var eMailAddress = obj as EMailAddress;
            if (eMailAddress == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readEMailAddress = db.EMailAddresses.Single(ema => ema.ObjectId.Equals(eMailAddress.ObjectId));
                readEMailAddress.Address = eMailAddress.Address;
                readEMailAddress.ContactType = eMailAddress.ContactType;
                readEMailAddress.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                db.EMailAddresses.Remove(this.Read(objectId) as EMailAddress);
                db.SaveChanges();
            }
        }
    }
}