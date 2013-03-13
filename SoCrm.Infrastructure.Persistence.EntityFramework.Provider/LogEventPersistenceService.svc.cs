using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider
{
    using SoCrm.Infrastructure.Persistence.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices;
    using SoCrm.Services.Logging.Contracts;

    public class LogEventPersistenceService : IPersistenceService<LogEvent>
    {
        private IDataService dataService;

        public LogEventPersistenceService()
        {
            this.dataService = DataServiceFactory.Create(typeof(LogEvent));
        }

        public void Save(LogEvent entity)
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

        public LogEvent Get(Guid objectId)
        {
            return (LogEvent)this.dataService.Read(objectId);
        }

        public IEnumerable<LogEvent> GetAll()
        {
            return this.dataService.Read().Cast<LogEvent>();
        }

        public void Remove(LogEvent entity)
        {
            this.dataService.Delete(entity.ObjectId);
        }
    }
}
