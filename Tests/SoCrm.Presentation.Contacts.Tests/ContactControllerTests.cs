namespace SoCrm.Presentation.Contacts.Tests
{
    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts.ContactList;
    using SoCrm.Presentation.Contacts.CreateContact;
    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Services.Customers.Contracts;

    [TestFixture]
    public class ContactControllerTests
    {
        private IUnityContainer unityContainer;

        private Mock<IStatusBarService> statusBarServiceMock;

        private Mock<IRegion> regionMock;

        private Mock<ICreateContactViewModel> createContactViewModelMock;

        private Mock<IContactListViewModel> contactListViewModelMock;

        [SetUp]
        public void SetUp()
        {
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.regionMock = new Mock<IRegion>();
            this.createContactViewModelMock = new Mock<ICreateContactViewModel>();
            this.contactListViewModelMock = new Mock<IContactListViewModel>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
            this.unityContainer.RegisterInstance(this.createContactViewModelMock.Object);
            this.unityContainer.RegisterInstance(this.contactListViewModelMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.regionMock = null;
            this.createContactViewModelMock = null;
            this.contactListViewModelMock = null;
            this.statusBarServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            var contactController = new ContactController(this.unityContainer, this.regionMock.Object);

            Assert.IsNotNull(contactController);
        }

        [Test]
        public void NavigateToCreateContact()
        {
            this.regionMock.SetupSet(r => r.Context = this.createContactViewModelMock.Object).Verifiable();
            var contactController = new ContactController(this.unityContainer, this.regionMock.Object);
            contactController.NavigateToCreateContact();

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToCreateContact_Person()
        {
            var person = new Person();
            this.regionMock.SetupSet(r => r.Context = this.createContactViewModelMock.Object).Verifiable();
            var contactController = new ContactController(this.unityContainer, this.regionMock.Object);
            contactController.NavigateToCreateContact(person);

            this.regionMock.Verify();
        }

        [Test]
        public void NavigateToContactList()
        {
            this.regionMock.SetupSet(r => r.Context = this.contactListViewModelMock.Object).Verifiable();
            var contactController = new ContactController(this.unityContainer, this.regionMock.Object);
            contactController.NavigateToContactList();

            this.regionMock.Verify();
        }
    }
}
