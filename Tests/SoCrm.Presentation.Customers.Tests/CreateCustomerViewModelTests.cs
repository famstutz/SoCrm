namespace SoCrm.Presentation.Customers.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Customers.CreateCustomer;
    using SoCrm.Services.Customers.Contracts;

    using ICustomerService = SoCrm.Presentation.Customers.Customer.ICustomerService;

    [TestFixture]
    public class CreateCustomerViewModelTests
    {
        private CreateCustomerViewModel createCustomerViewModel;

        private Mock<ICustomerController> customerControllerMock;

        private Mock<ICustomerService> customerServiceMock;

        private List<string> countries;

        private List<Company> companies;

        [SetUp]
        public void SetUp()
        {
            this.companies = this.CreateCompanies();
            this.countries = this.CreateCountries();

            this.customerControllerMock = new Mock<ICustomerController>();
            this.customerServiceMock = new Mock<ICustomerService>();
            this.customerServiceMock.Setup(s => s.GetAllCompanies()).Returns(this.companies);
            this.customerServiceMock.Setup(s => s.GetAllCountries()).Returns(this.countries);

            this.createCustomerViewModel = new CreateCustomerViewModel(
                this.customerControllerMock.Object, this.customerServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.createCustomerViewModel = null;
            this.customerControllerMock = null;
            this.customerServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.createCustomerViewModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            Assert.IsNotNull(this.createCustomerViewModel.CreateCustomerCommand);
            Assert.IsNotNull(this.createCustomerViewModel.CreateCompanyCommand);
            Assert.IsNotNull(this.createCustomerViewModel.CreateEMailAddressCommand);
            Assert.IsNotNull(this.createCustomerViewModel.CreatePhoneNumberCommand);
            Assert.IsNotNull(this.createCustomerViewModel.DeleteEMailAddressCommand);
            Assert.IsNotNull(this.createCustomerViewModel.DeletePhoneNumberCommand);
            Assert.IsNotNull(this.createCustomerViewModel.EMailAddresses);
            Assert.IsNotNull(this.createCustomerViewModel.PhoneNumbers);
            CollectionAssert.AreEqual(this.countries, this.createCustomerViewModel.Countries);
            CollectionAssert.AreEqual(this.companies, this.createCustomerViewModel.Companies);
        }

        [Test]
        public void FirstName()
        {
            var firstName = "Florian";

            this.createCustomerViewModel.FirstName = firstName;
            var result = this.createCustomerViewModel.FirstName;

            Assert.AreEqual(firstName, result);
        }

        [Test]
        public void LastName()
        {
            var lastName = "Amstutz";

            this.createCustomerViewModel.LastName = lastName;
            var result = this.createCustomerViewModel.LastName;

            Assert.AreEqual(lastName, result);
        }

        [Test]
        public void AddressLine()
        {
            var addressLine = "Gräbligasse 12";

            this.createCustomerViewModel.AddressLine = addressLine;
            var result = this.createCustomerViewModel.AddressLine;

            Assert.AreEqual(addressLine, result);
        }

        [Test]
        public void ZipCode()
        {
            var zipCode = "8001";

            this.createCustomerViewModel.ZipCode = zipCode;
            var result = this.createCustomerViewModel.ZipCode;

            Assert.AreEqual(zipCode, result);
        }

        [Test]
        public void City()
        {
            var city = "Zürich";

            this.createCustomerViewModel.City = city;
            var result = this.createCustomerViewModel.City;

            Assert.AreEqual(city, result);
        }

        [Test]
        public void Countries()
        {
            this.createCustomerViewModel.Countries = new ObservableCollection<string>(this.countries);
            var result = this.createCustomerViewModel.Countries;

            CollectionAssert.AreEqual(this.countries, result);
        }

        [Test]
        public void Country()
        {
            var country = "Hungary";

            this.createCustomerViewModel.Country = country;
            var result = this.createCustomerViewModel.Country;

            Assert.AreEqual(country, result);
        }
        
        [Test]
        public void Company()
        {
            var company = new Company { ObjectId = Guid.NewGuid(), Name = "Ragusa AG" };

            this.createCustomerViewModel.Company = company;
            var result = this.createCustomerViewModel.Company;

            Assert.AreEqual(company, result);
        }

        [Test]
        public void Companies()
        {
            this.createCustomerViewModel.Companies = new ObservableCollection<Company>(this.companies);
            var result = this.createCustomerViewModel.Companies;

            CollectionAssert.AreEqual(this.companies, result);
        }

        [Test]
        public void EMailAddresses()
        {
            var emailAddresses = new List<EMailAddress>
                                     {
                                         new EMailAddress
                                             {
                                                 ObjectId = Guid.NewGuid(),
                                                 Address = "info@google.com"
                                             },
                                         new EMailAddress
                                             {
                                                 ObjectId = Guid.NewGuid(),
                                                 Address = "gugus@ragusa.ch"
                                             }
                                     };

            this.createCustomerViewModel.EMailAddresses = new ObservableCollection<EMailAddress>(emailAddresses);
            var result = this.createCustomerViewModel.EMailAddresses;

            CollectionAssert.AreEqual(emailAddresses, result);
        }

        [Test]
        public void SelectedEMailAddress()
        {
            var emailAddress = new EMailAddress { ObjectId = Guid.NewGuid(), Address = "info@caotina.ch" };

            this.createCustomerViewModel.SelectedEMailAddress = emailAddress;
            var result = this.createCustomerViewModel.SelectedEMailAddress;

            Assert.AreEqual(emailAddress, result);
        }

        [Test]
        public void PhoneNumbers()
        {
            var phoneNumbers = new List<PhoneNumber>
                                   {
                                       new PhoneNumber
                                           {
                                               ObjectId = Guid.NewGuid(),
                                               Number = "829358952833"
                                           },
                                       new PhoneNumber
                                           {
                                               ObjectId = Guid.NewGuid(),
                                               Number = "079 322 13 22"
                                           }
                                   };

            this.createCustomerViewModel.PhoneNumbers = new ObservableCollection<PhoneNumber>(phoneNumbers);
            var result = this.createCustomerViewModel.PhoneNumbers;

            CollectionAssert.AreEqual(phoneNumbers, result);
        }

        [Test]
        public void SelectedPhoneNumber()
        {
            var phoneNumber = new PhoneNumber { ObjectId = Guid.NewGuid(), Number = "82952938343" };

            this.createCustomerViewModel.SelectedPhoneNumber = phoneNumber;
            var result = this.createCustomerViewModel.SelectedPhoneNumber;

            Assert.AreEqual(phoneNumber, result);
        }

        [Test]
        public void CreateCustomerCommandExecute()
        {
            var firstName = "Peter";
            var lastName = "Muster";
            var company = this.CreateCompanies().First();
            var addressLine = "Wydäckerring 63";
            var zipCode = "8046";
            var city = "Zürich";
            var country = "Switzerland";
            var phoneNumbers = new List<PhoneNumber>
                                   {
                                       new PhoneNumber
                                           {
                                               ObjectId = Guid.NewGuid(),
                                               Number = "82952938343"
                                           }
                                   };
            var emailAddresses = new List<EMailAddress>
                                     {
                                         new EMailAddress
                                             {
                                                 ObjectId = Guid.NewGuid(),
                                                 Address = "info@caotina.ch"
                                             }
                                     };
            this.createCustomerViewModel.FirstName = firstName;
            this.createCustomerViewModel.LastName = lastName;
            this.createCustomerViewModel.AddressLine = addressLine;
            this.createCustomerViewModel.ZipCode = zipCode;
            this.createCustomerViewModel.City = city;
            this.createCustomerViewModel.Country = country;
            this.createCustomerViewModel.Company = company;
            this.createCustomerViewModel.EMailAddresses = new ObservableCollection<EMailAddress>(emailAddresses);
            this.createCustomerViewModel.PhoneNumbers = new ObservableCollection<PhoneNumber>(phoneNumbers);

            this.customerServiceMock.Setup(
                s =>
                s.CreatePerson(
                    firstName, lastName, company, addressLine, zipCode, city, country, phoneNumbers, emailAddresses))
                .Returns(
                    new Person
                        {
                            ObjectId = Guid.NewGuid(),
                            Address =
                                new Address
                                    {
                                        ObjectId = Guid.NewGuid(),
                                        AddressLine = addressLine,
                                        City = city,
                                        Country = country,
                                        ZipCode = zipCode
                                    },
                            Employer = company,
                            EMailAddresses = emailAddresses,
                            FirstName = firstName,
                            LastName = lastName,
                            PhoneNumbers = phoneNumbers
                        });

            this.createCustomerViewModel.CreateCustomerCommand.Execute(null);

            this.customerServiceMock.Verify(
                s =>
                s.CreatePerson(
                    firstName, lastName, company, addressLine, zipCode, city, country, phoneNumbers, emailAddresses));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
            this.customerControllerMock.Verify(s => s.NavigateToCustomerList());
        }

        [Test]
        public void CreateCompanyCommandExecute()
        {
            this.createCustomerViewModel.CreateCompanyCommand.Execute(null);

            this.customerControllerMock.Verify(s => s.NavigateToCreateCompany());
        }

        [Test]
        public void CreateEMailAddressCommandExecute()
        {
            this.createCustomerViewModel.CreateEMailAddressCommand.Execute(null);

            this.customerControllerMock.Verify(s => s.NavigateToCreateEMailAddress());
        }

        [Test]
        public void CreatePhoneNumberCommandExecute()
        {
            this.createCustomerViewModel.CreatePhoneNumberCommand.Execute(null);

            this.customerControllerMock.Verify(s => s.NavigateToCreatePhoneNumber());
        }

        [Test]
        public void DeleteEMailAddressCommandExecute()
        {
            var emailAddress = new EMailAddress { ObjectId = Guid.NewGuid(), Address = "info@caotina.ch" };
            this.customerServiceMock.Setup(s => s.DeleteEMailAddress(emailAddress));

            this.createCustomerViewModel.DeleteEMailAddressCommand.Execute(emailAddress);

            this.customerServiceMock.Verify(s => s.DeleteEMailAddress(emailAddress));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        [Test]
        public void DeletePhoneNumberCommandExecute()
        {
            var phoneNumber = new PhoneNumber { ObjectId = Guid.NewGuid(), Number = "82952938343" };
            this.customerServiceMock.Setup(s => s.DeletePhoneNumber(phoneNumber));

            this.createCustomerViewModel.DeletePhoneNumberCommand.Execute(phoneNumber);

            this.customerServiceMock.Verify(s => s.DeletePhoneNumber(phoneNumber));
            this.customerControllerMock.Verify(s => s.SetLastStatus(It.IsAny<string>()));
        }

        private List<string> CreateCountries()
        {
            return new List<string> { "Switzerland", "Germany" };
        }

        private List<Company> CreateCompanies()
        {
            return new List<Company>
                       {
                           new Company { ObjectId = Guid.NewGuid(), Name = "Hanswurscht AG" },
                           new Company { ObjectId = Guid.NewGuid(), Name = "Ueli GmbH" }
                       };
        }
    }
}
