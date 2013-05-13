namespace SoCrm.Presentation.Security.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Security.UserList;
    using SoCrm.Services.Security.Contracts;

    using ISecurityService = SoCrm.Presentation.Security.Security.ISecurityService;

    [TestFixture]
    public class UserListViewModelTests
    {
        private UserListViewModel userListViewModel;

        private Mock<ISecurityController> securityControllerMock;

        private Mock<ISecurityService> securityServiceMock;

        private List<Role> roles;

        private List<User> users;

        [SetUp]
        public void SetUp()
        {
            this.roles = new List<Role> { Role.Administrator, Role.User };
            this.users = new List<User>
                             {
                                 new User
                                     {
                                         ObjectId = Guid.NewGuid(),
                                         UserName = "Florian",
                                         Password = "Test123",
                                         Role = Role.Administrator
                                     }
                             };

            this.securityControllerMock = new Mock<ISecurityController>();
            this.securityServiceMock = new Mock<ISecurityService>();
            this.securityServiceMock.Setup(s => s.GetAllRoles()).Returns(this.roles);
            this.securityServiceMock.Setup(s => s.GetUsersByRole(It.IsAny<Role>())).Returns(this.users);
            this.userListViewModel = new UserListViewModel(
                this.securityControllerMock.Object, this.securityServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.userListViewModel = null;
            this.securityControllerMock = null;
            this.securityServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.userListViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.userListViewModel.SearchUsersCommand);
            Assert.IsNotNull(this.userListViewModel.DeleteUserCommand);
            Assert.IsNotNull(this.userListViewModel.SetPasswordCommand);
            Assert.IsNotNull(this.userListViewModel.SelectedUsers);

            CollectionAssert.AreEqual(this.roles, this.userListViewModel.Roles);
            CollectionAssert.AreEqual(this.users, this.userListViewModel.Users);
        }

        [Test]
        public void Roles()
        {
            var newRoles = new ObservableCollection<Role> { Role.Administrator };

            this.userListViewModel.Roles = newRoles;
            var result = this.userListViewModel.Roles;

            CollectionAssert.AreEqual(newRoles, result);
        }

        [Test]
        public void Users()
        {
            var newUsers = new ObservableCollection<User>
                               {
                                   new User
                                       {
                                           ObjectId = Guid.NewGuid(),
                                           UserName = "Peter",
                                           Password = "SecreTPW",
                                           Role = Role.User
                                       }
                               };

            this.userListViewModel.Users = newUsers;
            var result = this.userListViewModel.Users;

            CollectionAssert.AreEqual(newUsers, result);
        }

        [Test]
        public void SearchUserName()
        {
            var userName = "Ueli";

            this.userListViewModel.SearchUserName = userName;
            var result = this.userListViewModel.SearchUserName;

            Assert.AreEqual(userName, result);
        }

        [Test]
        public void SearchRole()
        {
            var role = Role.User;

            this.userListViewModel.SearchRole = role;
            var result = this.userListViewModel.SearchRole;

            Assert.AreEqual(role, result);
        }

        [Test]
        public void SelectedUser()
        {
            var user = new User
                           {
                               ObjectId = Guid.NewGuid(),
                               UserName = "Peter",
                               Password = "SecreTPW",
                               Role = Role.User
                           };

            this.userListViewModel.SelectedUser = user;
            var result = this.userListViewModel.SelectedUser;

            Assert.AreEqual(user, result);
        }

        [Test]
        public void SelectedUsers()
        {
            var selectedUsers = new ObservableCollection<User>
                                    {
                                        new User
                                            {
                                                ObjectId = Guid.NewGuid(),
                                                UserName = "Peter",
                                                Password = "SecreTPW",
                                                Role = Role.User
                                            }
                                    };

            this.userListViewModel.SelectedUsers = selectedUsers;
            var result = this.userListViewModel.SelectedUsers;

            CollectionAssert.AreEqual(selectedUsers, result);
        }

        [Test]
        public void SearchUsersCommandExecute()
        {
            this.securityServiceMock.Setup(s => s.GetUsersByRoleAndUserName(It.IsAny<Role>(), It.IsAny<string>())).Returns(this.users);

            this.userListViewModel.SearchUsersCommand.Execute(null);

            CollectionAssert.AreEqual(this.users, this.userListViewModel.Users);
            this.securityServiceMock.Verify(s => s.GetUsersByRoleAndUserName(It.IsAny<Role>(), It.IsAny<string>()));
        }

        [Test]
        public void DeleteUserCommandExecute()
        {
            var user = this.users.First();
            this.securityServiceMock.Setup(s => s.DeleteUser(It.IsAny<User>()));
            this.securityControllerMock.Setup(s => s.SetLastStatus(It.IsAny<string>()));

            this.userListViewModel.DeleteUserCommand.Execute(user);

            this.securityServiceMock.Verify(s => s.DeleteUser(It.IsAny<User>()));
            this.securityControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void SetPasswordCommandExecute()
        {
            var user = this.users.First();
            this.securityControllerMock.Setup(s => s.NavigateToSetPassword(It.IsAny<User>()));

            this.userListViewModel.SetPasswordCommand.Execute(user);

            this.securityControllerMock.Verify(s => s.NavigateToSetPassword(It.IsAny<User>()));
        }
    }
}
