// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyDataService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The company data service.
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
    /// The company data service.
    /// </summary>
    public class CompanyDataService : IDataService
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

            if (company.Address != null)
            {
                if (company.Address.ObjectId == default(Guid))
                {
                    company.Address.ObjectId = Guid.NewGuid();
                }

                company.Address.CreationTimeStamp = DateTime.Now;
                company.Address.LastUpdateTimeStamp = DateTime.Now;
            }

            using (var db = new CustomerContext())
            {
                db.Companies.Add(company);
                db.SaveChanges();
            }

            return company.ObjectId;
        }

        /// <summary>
        /// Reads this instance.
        /// </summary>
        /// <returns>The companies.</returns>
        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new CustomerContext())
            {
                return db.Companies.Include("Address").ToList();
            }
        }

        /// <summary>
        /// Reads the specified object id.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The company.</returns>
        public IDomainObject Read(Guid objectId)
        {
            using (var db = new CustomerContext())
            {
                return db.Companies.Include("Address").Single(c => c.ObjectId.Equals(objectId));
            }
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <exception cref="System.NotSupportedException">Thrown if the object is not of the expected type.</exception>
        public void Update(IDomainObject obj)
        {
            var company = obj as Company;
            if (company == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new CustomerContext())
            {
                var readCompany = db.Companies.Include("Address").Single(c => c.ObjectId.Equals(company.ObjectId));
                readCompany.Name = company.Name;
                readCompany.Address = company.Address;
                readCompany.LastUpdateTimeStamp = DateTime.Now;
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
                var company = this.Read(objectId) as Company;
                db.Companies.Attach(company);
                db.Companies.Remove(company);
                db.SaveChanges();
            }
        }
    }
}