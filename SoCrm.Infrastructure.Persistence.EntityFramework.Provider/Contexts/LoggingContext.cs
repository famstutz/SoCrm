namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts
{
    using System.Data.Entity;

    using SoCrm.Services.Logging.Contracts;

    public class LoggingContext : DbContext
    {
       public DbSet<LogEvent> LogEvents { get; set; }

        public LoggingContext()
            : base("Name=SoCrm")
        {
            
        }
    }
}