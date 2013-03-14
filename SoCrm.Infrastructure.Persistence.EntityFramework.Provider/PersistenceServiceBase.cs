namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;

    public abstract class PersistenceServiceBase<T> : IPersistenceService<T> where T: IDomainObject
    {
        private IDataService dataService;

        protected PersistenceServiceBase()
        {
            this.dataService = DataServiceFactory.Create(typeof(T));
        }
        
        public void Save(T entity)
        {
            if (entity.CreationTimeStamp == default(DateTime))
            {
                this.dataService.Create(entity);
            }
            else
            {
                this.dataService.Update(entity);
            }
        }

        public T Get(Guid objectId)
        {
            return (T)this.dataService.Read(objectId);
        }

        public IEnumerable<T> GetAll()
        {
            return this.dataService.Read().Cast<T>();
        }

        public void Remove(T entity)
        {
            this.dataService.Delete(entity.ObjectId);
        }
    }
}