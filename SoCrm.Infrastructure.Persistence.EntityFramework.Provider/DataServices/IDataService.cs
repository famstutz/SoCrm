using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using SoCrm.Contracts;

    public interface IDataService
    {
        void Create(IDomainObject obj);

        IEnumerable<IDomainObject> Read();

        IDomainObject Read(Guid objectId);

        void Update(IDomainObject obj);

        void Delete(Guid objectId);
    }
}
