namespace SoCrm.Infrastructure.Persistence.EntityFramework.Provider.DataServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoCrm.Contracts;
    using SoCrm.Infrastructure.Persistence.EntityFramework.Provider.Contexts;
    using SoCrm.Services.Security.Contracts;

    public class UserDataService : IDataService
    {
        public void Create(IDomainObject obj)
        {
            var user = obj as User;
            if (user == null)
            {
                throw new NotSupportedException(string.Format("UserDataService cannot deal with supplied type"));
            }

            if (user.ObjectId == default(Guid))
            {
                user.ObjectId = Guid.NewGuid();
            }

            user.CreationTimeStamp = DateTime.Now;
            user.LastUpdateTimeStamp = DateTime.Now;

            using (var db = new SecurityContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public IEnumerable<IDomainObject> Read()
        {
            using (var db = new SecurityContext())
            {
                return db.Users.ToList();
            }
        }

        public IDomainObject Read(Guid objectId)
        {
            using (var db = new SecurityContext())
            {
                return db.Users.Single(le => le.ObjectId.Equals(objectId));
            }
        }

        public void Update(IDomainObject obj)
        {
            var user = obj as User;
            if (user == null)
            {
                throw new NotSupportedException(string.Format("UserDataService cannot deal with supplied type"));
            }

            using (var db = new SecurityContext())
            {
                var readUser = db.Users.Single(le => le.ObjectId.Equals(user.ObjectId));
                readUser.UserName = user.UserName;
                readUser.Role = user.Role;
                readUser.Password = user.Password;
                readUser.LastUpdateTimeStamp = DateTime.Now;
                db.SaveChanges();
            }
        }

        public void Delete(Guid objectId)
        {
            using (var db = new SecurityContext())
            {
                db.Users.Remove(this.Read(objectId) as User);
                db.SaveChanges();
            }
        }
    }
}