// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersistenceServiceBase.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The persistence service base class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Infrastructure.Persistence.NHibernate
{
    using System;
    using System.Collections.Generic;

    using SoCrm.Core.Contracts;

    /// <summary>
    /// The persistence service base class.
    /// </summary>
    /// <typeparam name="T">The type of domain object.</typeparam>
    public abstract class PersistenceServiceBase<T> where T : class, IDomainObject
    { 
        /// <summary>
        /// The database name.
        /// </summary>
        private readonly string databaseName;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistenceServiceBase{T}"/> class.
        /// </summary>
        /// <param name="databaseName">Name of the database.</param>
        protected PersistenceServiceBase(string databaseName)
        {
            this.databaseName = databaseName;
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <param name="objectId">The object id.</param>
        /// <returns>The entity.</returns>
        protected T GetEntity(Guid objectId)
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory(this.databaseName);

            using (var session = sessionFactory.OpenSession())
            {
                return session.Get<T>(objectId);
            }
        }

        /// <summary>
        /// The get all entities.
        /// </summary>
        /// <returns>
        /// All the entities.
        /// </returns>
        protected IEnumerable<T> GetAllEntities()
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory(this.databaseName);

            using (var session = sessionFactory.OpenSession())
            {
                return session.CreateCriteria<T>().List<T>();
            }
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void RemoveEntity(T entity)
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory(this.databaseName);

            using (var session = sessionFactory.OpenSession())
            {
                session.Delete(entity);
                session.Flush();
            }
        }

        /// <summary>
        /// Saves the or update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Guid"/>.
        /// </returns>
        protected Guid SaveOrUpdateEntity(T entity)
        {
            var sessionFactory = NHibernateHelper.CreateSessionFactory(this.databaseName);

            using (var session = sessionFactory.OpenSession())
            {
                var storedEntity = this.GetEntity(entity.ObjectId);

                if (storedEntity == null)
                {
                    if (entity.ObjectId == default(Guid))
                    {
                        entity.ObjectId = Guid.NewGuid();
                    }

                    entity.CreationTimeStamp = DateTime.Now;
                    entity.LastUpdateTimeStamp = DateTime.Now;

                    session.Save(entity);
                }
                else
                {
                    entity.LastUpdateTimeStamp = DateTime.Now;
                    session.Update(entity);
                }

                session.Flush();

                return entity.ObjectId;
            }
        }
    }
}