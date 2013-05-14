namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CreateEMailAddress;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CreateEMailAddressViewModelTests
    {
        private CreateEMailAddressViewModel createEMailAddressViewModel;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<ICustomerService> customerServiceMock;

        private List<ContactType> contactTypes;

        [SetUp]
        public void SetUp()
        {
            this.contactTypes = new List<ContactType>
                                    {
                                        Services.Customers.Contracts.ContactType.Company,
                                        Services.Customers.Contracts.ContactType.Private
                                    };
            this.customerControllerMock = new Mock<ICustomerController>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.customerServiceMock.Setup(s => s.GetContactTypes()).Returns(this.contactTypes);
            this.createEMailAddressViewModel = new CreateEMailAddressViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createEMailAddressViewModel = null;
            this.customerServiceMock = null;
            this.customerControllerMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createEMailAddressViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.createEMailAddressViewModel.CreateEMailAddressCommand);
            CollectionAssert.AreEqual(this.contactTypes, this.createEMailAddressViewModel.ContactTypes);
        }

        [Test]
        public void Address()
        {
            var address = "test@google.com";

            this.createEMailAddressViewModel.Address = address;
            var result = this.createEMailAddressViewModel.Address;

            Assert.AreEqual(address, result);
        }

        [Test]
        public void ContactTypes()
        {
            this.createEMailAddressViewModel.ContactTypes = new ObservableCollection<ContactType>(this.contactTypes);
            var result = this.createEMailAddressViewModel.ContactTypes;

            Assert.AreEqual(this.contactTypes, result);
        }

        [Test]
        public void ContactType()
        {
            var contactType = Services.Customers.Contracts.ContactType.Private;

            this.createEMailAddressViewModel.ContactType = contactType;
            var result = this.createEMailAddressViewModel.ContactType;

            Assert.AreEqual(contactType, result);
        }

        [Test]
        public void CreateEMailAddressCommandExecute()
        {
            var address = "test@google.com";
            var contactType = Services.Customers.Contracts.ContactType.Private;
            var emailAddress = new EMailAddress
                                   {
                                       ObjectId = Guid.NewGuid(),
                                       Address = address,
                                       ContactType = contactType
                                   };
            this.createEMailAddressViewModel.Address = address;
            this.createEMailAddressViewModel.ContactType = contactType;
            this.customerServiceMock.Setup(s => s.CreateEMailAddress(address, contactType)).Returns(emailAddress);

            this.createEMailAddressViewModel.CreateEMailAddressCommand.Execute(null);

            this.customerServiceMock.Verify(s => s.CreateEMailAddress(address, contactType));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.customerControllerMock.Verify(s => s.NavigateBackToCreateCustomer(emailAddress));

        }
    }
}
