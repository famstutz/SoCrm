namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CreatePhoneNumber;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CreatePhoneNumberViewModelTests
    {
        private CreatePhoneNumberViewModel createPhoneNumberViewModel;

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
            this.createPhoneNumberViewModel = new CreatePhoneNumberViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createPhoneNumberViewModel = null;
            this.customerServiceMock = null;
            this.customerControllerMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createPhoneNumberViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.createPhoneNumberViewModel.CreatePhoneNumberCommand);
            CollectionAssert.AreEqual(this.contactTypes, this.createPhoneNumberViewModel.ContactTypes);
        }

        [Test]
        public void Number()
        {
            var number = "230403949238";

            this.createPhoneNumberViewModel.Number = number;
            var result = this.createPhoneNumberViewModel.Number;

            Assert.AreEqual(number, result);
        }

        [Test]
        public void ContactTypes()
        {
            this.createPhoneNumberViewModel.ContactTypes = new ObservableCollection<ContactType>(this.contactTypes);
            var result = this.createPhoneNumberViewModel.ContactTypes;

            Assert.AreEqual(this.contactTypes, result);
        }

        [Test]
        public void ContactType()
        {
            var contactType = Services.Customers.Contracts.ContactType.Private;

            this.createPhoneNumberViewModel.ContactType = contactType;
            var result = this.createPhoneNumberViewModel.ContactType;

            Assert.AreEqual(contactType, result);
        }

        [Test]
        public void CreatePhoneNumberCommandExecute()
        {
            var number = "3984923493";
            var contactType = Services.Customers.Contracts.ContactType.Private;
            var phoneNumber = new PhoneNumber
            {
                ObjectId = Guid.NewGuid(),
                Number = number,
                ContactType = contactType
            };
            this.createPhoneNumberViewModel.Number = number;
            this.createPhoneNumberViewModel.ContactType = contactType;
            this.customerServiceMock.Setup(s => s.CreatePhoneNumber(number, contactType)).Returns(phoneNumber);

            this.createPhoneNumberViewModel.CreatePhoneNumberCommand.Execute(null);

            this.customerServiceMock.Verify(s => s.CreatePhoneNumber(number, contactType));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.customerControllerMock.Verify(s => s.NavigateBackToCreateCustomer(phoneNumber));

        }
    }
}
