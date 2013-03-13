namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Logging.Contracts;

    public class LogEventDataService : IDataService
    {
        public void Create(IDomainObject obj)
        {
            var logEvent = obj as LogEvent;
            if (logEvent == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            if (logEvent.ObjectId == default(Guid))
            {
                logEvent.ObjectId = Guid.NewGuid();
            }

            logEvent.CreationTimeStamp = DateTime.Now;
            logEvent.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new LoggingContext())
            {
                db.LogEvents.Add(logEvent);
                db.SaveChanges();
            }
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new LoggingContext())
            {
                return db.LogEvents.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new LoggingContext())
            {
                return db.LogEvents.Single(le => le.ObjectId.Equals(objectId));
            }
        }

        public void Update(IDomainObject obj)
        {
            var logEvent = obj as LogEvent;
            if (logEvent == null)
            {
                throw new NotSupportedException(string.Format("LogEventDataService cannot deal with supplied type"));
            }

            using (var db = new LoggingContext())
            {
                var readLogEvent = db.LogEvents.Single(le => le.ObjectId.Equals(logEvent.ObjectId));
                readLogEvent.Message = logEvent.Message;
                readLogEvent.Severity = logEvent.Severity;
                readLogEvent.TimeStamp = logEvent.TimeStamp;
                readLogEvent.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(Guid objectId)
        {
            using (var db = new LoggingContext())
            {
                db.LogEvents.Remove(this.Read(objectId) as LogEvent);
                db.SaveChanges();
            }
        }
    }
}