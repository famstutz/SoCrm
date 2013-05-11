// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogEventMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The log event map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using SoCrm.Services.Logging.Contracts;

    /// <summary>
    /// The log event map.
    /// </summary>
    public class LogEventMap : DomainObjectMap<LogEvent>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEventMap"/> class.
        /// </summary>
        public LogEventMap()
        {
            this.Table("LogEvents");
            
            this.Map(x => x.Severity).CustomType(typeof(Severity));
            this.Map(x => x.Message);
            this.Map(x => x.TimeStamp);
        }
    }
}