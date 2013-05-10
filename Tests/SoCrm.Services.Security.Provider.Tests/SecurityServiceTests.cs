namespace SoCrm.Services.Security.Provider.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Authentication;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Services.Security.Contracts;
    using SoCrm.Services.Security.Provider.UserPersistence;

    [TestFixture]
    public class SecurityServiceTests
    {
        private Mock<IPersistenceServiceOf_User> userClientMock;

        private SecurityService securityService;

        [SetUp]
        public void SetUp()
        {
            this.userClientMock = new Mock<IPersistenceServiceOf_User>();
            this.securityService = new SecurityService(this.userClientMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.securityService = null;
            this.userClientMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.securityService);
        }

        [Test]
        public void GetAllUsers()
        {
            var users = this.GetUsers();
            this.userClientMock.Setup(u => u.GetAll()).Returns(users);

            var result = this.securityService.GetAllUsers();

            CollectionAssert.AreEqual(users, result);
            this.userClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void GetAllRoles()
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>();

            var result = this.securityService.GetAllRoles();

            CollectionAssert.AreEqual(roles, result);
        }

        [Test]
        public void GetUsersByRole()
        {
            var users = this.GetUsers();
            this.userClientMock.Setup(u => u.GetAll()).Returns(users);

            var result = this.securityService.GetUsersByRole(Role.Administrator);

            CollectionAssert.AreEqual(users.Where(u => u.Role == Role.Administrator), result);
        }

        [Test]
        public void GetUsersByRoleAndUserName()
        {
            var users = this.GetUsers();
            this.userClientMock.Setup(u => u.GetAll()).Returns(users);

            var result = this.securityService.GetUsersByRoleAndUserName(Role.Administrator, "Ueli");

            CollectionAssert.AreEqual(users.Where(u => u.Role == Role.Administrator && u.UserName.Equals("Ueli")), result);
        }

        [Test]
        public void ValidateCredentials()
        {
            var user = this.GetUser();
            var userList = new List<User> { user };
            this.userClientMock.Setup(u => u.GetAll()).Returns(userList);

            var result = this.securityService.ValidateCredentials(user.UserName, "test123");

            Assert.AreEqual(true, result);
            this.userClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void ValidateCredentials_WrongPassword()
        {
            var user = this.GetUser();
            var userList = new List<User> { user };
            this.userClientMock.Setup(u => u.GetAll()).Returns(userList);

            var result = this.securityService.ValidateCredentials(user.UserName, "NotTheUsersPassword");

            Assert.AreEqual(false, result);
            this.userClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void GetUserByCredentials()
        {
            var user = this.GetUser();
            var userList = new List<User> { user };
            this.userClientMock.Setup(u => u.GetAll()).Returns(userList);

            var result = this.securityService.GetUserByCredentials(user.UserName, "test123");

            Assert.AreEqual(user, result);
            this.userClientMock.Verify(u => u.GetAll());
        }

        [Test]
        [ExpectedException(typeof(InvalidCredentialException))]
        public void GetUserByCredentials_WrongPassword()
        {
            var user = this.GetUser();
            var userList = new List<User> { user };
            this.userClientMock.Setup(u => u.GetAll()).Returns(userList);

            var result = this.securityService.GetUserByCredentials(user.UserName, "NotTheUsersPassword");

            Assert.AreEqual(user, result);
            this.userClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void GetUserByObjectId()
        {
            var user = this.GetUser();
            this.userClientMock.Setup(u => u.Get(user.ObjectId)).Returns(user);

            var result = this.securityService.GetUserByObjectId(user.ObjectId);

            Assert.AreEqual(user, result);
            this.userClientMock.Verify(u => u.Get(user.ObjectId));
        }

        [Test]
        public void SetPassword()
        {
            var user = this.GetUser();
            var userList = new List<User> { user };
            this.userClientMock.Setup(u => u.GetAll()).Returns(userList);
            this.userClientMock.Setup(u => u.Save(user)).Returns(user.ObjectId);

            this.securityService.SetPassword(user, "test123", "newPw8293");

            this.userClientMock.Verify(u => u.GetAll());
            this.userClientMock.Verify(u => u.Save(user));
        }

        [Test]
        public void CreateUser()
        {
            var user = this.GetUser();
            this.userClientMock.Setup(c => c.Save(It.IsAny<User>())).Returns(user.ObjectId);
            this.userClientMock.Setup(c => c.Get(user.ObjectId)).Returns(user);

            var result = this.securityService.CreateUser(user.UserName, user.Password, user.Role);

            Assert.AreEqual(user.ObjectId, result.ObjectId);
            this.userClientMock.Verify(c => c.Save(It.IsAny<User>()));
            this.userClientMock.Verify(c => c.Get(user.ObjectId));
        }

        [Test]
        public void DeleteUser()
        {
            var user = this.GetUser();
            this.userClientMock.Setup(c => c.Remove(user));

            this.securityService.DeleteUser(user);
            this.userClientMock.Verify(c => c.Remove(user));
        }

        private User GetUser()
        {
            return new User
                       {
                           ObjectId = Guid.Parse("F3AD00E1-0D86-4A09-AB1A-FB604D06FBB3"),
                           Password = "7NcYcNGWMxapfjrDQIyYNa2M8PPBvHA1J8MCZVNPda4=", // plain text: "test123"
                           UserName = "Hans",
                           Role = Role.User
                       };
        }

        private List<User> GetUsers()
        {
            return new List<User>
                       {
                           new User
                               {
                                   ObjectId = Guid.Parse("2E79983A-08C3-4182-9A9F-19AD6887A418"),
                                   Password = "PQTa86933aHeobbAJbRszkwDMZhPqQFipBOMvFr1wgE=", // plain text: "KJg3895"
                                   UserName = "Peter",
                                   Role = Role.User
                               },
                           new User
                               {
                                   ObjectId = Guid.Parse("D1C023F7-D6E2-46D4-B971-F2E332093499"),
                                   Password = "ESRR3pkQUV/V2zvkfmfIwhZLJXGUlssLBNeJLfjluVs=", // plain text: "JxKG239"
                                   UserName = "Ueli",
                                   Role = Role.Administrator
                               }
                       };
        }
    }
}
