// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainObjectMap.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The domain object map.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate.Mappings
{
    using FluentNHibernate.Mapping;

    using SoCrm.Contracts;

    /// <summary>
    /// The domain object map.
    /// </summary>
    /// <typeparam name="T">Type of domain object.</typeparam>
    public abstract class DomainObjectMap<T> : ClassMap<T> where T : IDomainObject 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainObjectMap{T}"/> class.
        /// </summary>
        protected DomainObjectMap()
        {
            this.Id(x => x.ObjectId).GeneratedBy.Assigned();
            this.Map(x => x.CreationTimeStamp);
            this.Map(x => x.LastUpdateTimeStamp);

            this.Not.LazyLoad();
        }
    }
}