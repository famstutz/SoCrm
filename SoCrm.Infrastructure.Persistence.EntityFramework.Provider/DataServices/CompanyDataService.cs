using System;
using System.Collections.Generic;
using System.Linq;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Customers.Contracts;

    public class CompanyDataService : IDataService
    {
        public void Create(IDomainObject obj)
        {
            var company = obj as Company;
            if (company == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (company.ObjectId == default(Guid))
            {
                company.ObjectId = Guid.NewGuid();
            }

            company.CreationTimeStamp = DateTime.Now;
            company.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new CustomerContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Companies.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Companies.Single(c => c.ObjectId.Equals(objectId));
            }
        }

        public void Update(IDomainObject obj)
        {
            var company = obj as Company;
            if (company == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readCompany = db.Companies.Single(c => c.ObjectId.Equals(company.ObjectId));
                readCompany.Name = company.Name;
                readCompany.Address = company.Address;
                readCompany.Employees = company.Employees;
                readCompany.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                db.Companies.Remove(this.Read(objectId) as Company);
                db.SaveChanges();
            }
        }
    }
}