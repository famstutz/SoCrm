namespace SoCrm.Infrastructure.Persistence.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using SoCrm.Contracts;

    [ServiceContract]
    public interface IPersistenceService<T> where T : IDomainObject
    {
        [OperationContract]
        void Save(T entity);
        [OperationContract]
        T Get(Guid objectId);
        [OperationContract]
        IEnumerable<T> GetAll();
        [OperationContract]
        void Remove(T entity);
    }
}
