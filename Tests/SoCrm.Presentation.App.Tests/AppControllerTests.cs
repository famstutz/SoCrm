namespace SoCrm.Presentation.App.Tests
{
    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Customers;
    using SoCrm.Presentation.Security;

    [TestFixture]
    public class AppControllerTests
    {
        private IUnityContainer unityContainer;

        private Mock<IStatusBarService> statusBarServiceMock;
            
        private Mock<ISecurityController> securityControllerMock;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<IContactController> contactControllerMock;

        [SetUp]
        public void SetUp()
        {
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.securityControllerMock = new Mock<ISecurityController>();
            this.customerControllerMock = new Mock<ICustomerController>();
            this.contactControllerMock = new Mock<IContactController>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
            this.unityContainer.RegisterInstance(this.securityControllerMock.Object);
            this.unityContainer.RegisterInstance(this.customerControllerMock.Object);
            this.unityContainer.RegisterInstance(this.contactControllerMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.securityControllerMock = null;
            this.statusBarServiceMock = null;
            this.customerControllerMock = null;
            this.contactControllerMock = null;
        }

        [Test]
        public void Constructor()
        {
            var appController = new AppController(this.unityContainer);

            Assert.IsNotNull(appController);
        }

        [Test]
        public void NavigateToUserList()
        {
            this.securityControllerMock.Setup(s => s.NavigateToUserList()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToUserList();

            this.securityControllerMock.Verify();
        }

        [Test]
        public void NavigateToCreateUser()
        {
            this.securityControllerMock.Setup(s => s.NavigateToCreateUser()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToCreateUser();

            this.securityControllerMock.Verify();
        }

        [Test]
        public void NavigateToCustomerList()
        {
            this.customerControllerMock.Setup(s => s.NavigateToCustomerList()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToCustomerList();

            this.customerControllerMock.Verify();
        }

        [Test]
        public void NavigateToCreateCustomer()
        {
            this.customerControllerMock.Setup(s => s.NavigateToCreateCustomer()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToCreateCustomer();

            this.customerControllerMock.Verify();
        }

        [Test]
        public void NavigateToCompanyList()
        {
            this.customerControllerMock.Setup(s => s.NavigateToCompanyList()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToCompanyList();

            this.customerControllerMock.Verify();
        }

        [Test]
        public void NavigateToAuthentication()
        {
            this.securityControllerMock.Setup(s => s.NavigateToAuthentication()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToAuthentication();

            this.securityControllerMock.Verify();
        }

        [Test]
        public void NavigateToContactList()
        {
            this.contactControllerMock.Setup(s => s.NavigateToContactList()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToContactList();

            this.contactControllerMock.Verify();
        }

        [Test]
        public void NavigateToCreateContact()
        {
            this.contactControllerMock.Setup(s => s.NavigateToCreateContact()).Verifiable();
            var appController = new AppController(this.unityContainer);

            appController.NavigateToCreateContact();

            this.contactControllerMock.Verify();
        }
    }
}
