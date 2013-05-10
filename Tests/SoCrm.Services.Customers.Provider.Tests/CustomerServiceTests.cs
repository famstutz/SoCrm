namespace SoCrm.Services.Customers.Provider.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Customers.Provider.AddressPersistence;
    using SoCrm.Services.Customers.Provider.CompanyPersistence;
    using SoCrm.Services.Customers.Provider.EMailAddressPersistence;
    using SoCrm.Services.Customers.Provider.PersonPersistence;
    using SoCrm.Services.Customers.Provider.PhoneNumberPersistence;

    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<IPersistenceServiceOf_Address> addressClientMock;

        private Mock<IPersistenceServiceOf_Company> companyClientMock;

        private Mock<IPersistenceServiceOf_EMailAddress> emailAddressClientMock;

        private Mock<IPersistenceServiceOf_Person> personClientMock;

        private Mock<IPersistenceServiceOf_PhoneNumber> phoneNumberClientMock;

        private CustomerService customerService;

        [SetUp]
        public void SetUp()
        {
            this.addressClientMock = new Mock<IPersistenceServiceOf_Address>();
            this.companyClientMock = new Mock<IPersistenceServiceOf_Company>();
            this.emailAddressClientMock = new Mock<IPersistenceServiceOf_EMailAddress>();
            this.personClientMock = new Mock<IPersistenceServiceOf_Person>();
            this.phoneNumberClientMock = new Mock<IPersistenceServiceOf_PhoneNumber>();
            this.customerService = new CustomerService(
                this.addressClientMock.Object,
                this.companyClientMock.Object,
                this.emailAddressClientMock.Object,
                this.personClientMock.Object,
                this.phoneNumberClientMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.addressClientMock = null;
            this.companyClientMock = null;
            this.emailAddressClientMock = null;
            this.personClientMock = null;
            this.phoneNumberClientMock = null;
            this.customerService = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.customerService);
        }

        [Test]
        public void GetAllPersons()
        {
            var persons = this.GetPersons();
            this.personClientMock.Setup(p => p.GetAll()).Returns(persons);

            var result = this.customerService.GetAllPersons();

            CollectionAssert.AreEqual(persons, result);
            this.personClientMock.Verify(p => p.GetAll());
        }

        [Test]
        public void GetAllCompanies()
        {
            var companies = this.GetCompanies();
            this.companyClientMock.Setup(c => c.GetAll()).Returns(companies);

            var result = this.customerService.GetAllCompanies();

            CollectionAssert.AreEqual(companies, result);
            this.companyClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetAllCountries()
        {
            var countries = this.GetCountries();

            var result = this.customerService.GetAllCountries();

            CollectionAssert.AreEqual(countries, result);
        }

        [Test]
        public void GetAllEMailAddresses()
        {
            var emailAddresses = this.GetEMailAddresses();
            this.emailAddressClientMock.Setup(e => e.GetAll()).Returns(emailAddresses);

            var result = this.customerService.GetAllEMailAddresses();

            CollectionAssert.AreEqual(emailAddresses, result);
            this.emailAddressClientMock.Verify(e => e.GetAll());
        }

        [Test]
        public void GetContactTypes()
        {
            var contactTypes = Enum.GetValues(typeof(ContactType)).Cast<ContactType>();

            var result = this.customerService.GetContactTypes();

            CollectionAssert.AreEqual(contactTypes, result);
        }

        [Test]
        public void GetAllPhoneNumbers()
        {
            var phoneNumbers = this.GetPhoneNumbers();
            this.phoneNumberClientMock.Setup(p => p.GetAll()).Returns(phoneNumbers);

            var result = this.customerService.GetAllPhoneNumbers();

            CollectionAssert.AreEqual(phoneNumbers, result);
            this.phoneNumberClientMock.Verify(p => p.GetAll());
        }

        [Test]
        public void GetPersonByObjectId()
        {
            var person = this.GetPerson();
            this.personClientMock.Setup(p => p.Get(person.ObjectId)).Returns(person);

            var result = this.customerService.GetPersonByObjectId(person.ObjectId);

            Assert.AreEqual(person, result);
            this.personClientMock.Verify(p => p.Get(person.ObjectId));
        }

        [Test]
        public void GetPersonsByNameAndCompany()
        {
            var personList = new List<Person> { this.GetPerson() };
            this.personClientMock.Setup(p => p.GetAll()).Returns(personList);

            var result = this.customerService.GetPersonsByNameAndCompany("Anjasson", "HOLM AG");

            CollectionAssert.AreEqual(personList, result);
            this.personClientMock.Verify(p => p.GetAll());
        }

        [Test]
        public void GetCompaniesByNameAndCountry()
        {
            var companyList = new List<Company> { this.GetCompany() };
            this.companyClientMock.Setup(c => c.GetAll()).Returns(companyList);

            var result = this.customerService.GetCompaniesByNameAndCountry("AIG", "United States of America");

            CollectionAssert.AreEqual(companyList, result);
            this.companyClientMock.Verify(c => c.GetAll());
        }

        [Test]
        public void GetCompanyByObjectId()
        {
            var company = this.GetCompany();
            this.companyClientMock.Setup(c => c.Get(company.ObjectId)).Returns(company);

            var result = this.customerService.GetCompanyByObjectId(company.ObjectId);

            Assert.AreEqual(company, result);
            this.companyClientMock.Verify(c => c.Get(company.ObjectId));
        }

        [Test]
        public void CreatePhoneNumber()
        {
            var phoneNumber = this.GetPhoneNumber();
            this.phoneNumberClientMock.Setup(c => c.Save(It.IsAny<PhoneNumber>())).Returns(phoneNumber.ObjectId);
            this.phoneNumberClientMock.Setup(c => c.Get(phoneNumber.ObjectId)).Returns(phoneNumber);

            var result = this.customerService.CreatePhoneNumber(phoneNumber.Number, phoneNumber.ContactType);

            Assert.AreEqual(phoneNumber.ObjectId, result.ObjectId);
            this.phoneNumberClientMock.Verify(c => c.Save(It.IsAny<PhoneNumber>()));
            this.phoneNumberClientMock.Verify(c => c.Get(phoneNumber.ObjectId));
        }

        [Test]
        public void CreateEMailAddress()
        {
            var emailAddress = this.GetEMailAddress();
            this.emailAddressClientMock.Setup(c => c.Save(It.IsAny<EMailAddress>())).Returns(emailAddress.ObjectId);
            this.emailAddressClientMock.Setup(c => c.Get(emailAddress.ObjectId)).Returns(emailAddress);

            var result = this.customerService.CreateEMailAddress(emailAddress.Address, emailAddress.ContactType);

            Assert.AreEqual(emailAddress.ObjectId, result.ObjectId);
            this.emailAddressClientMock.Verify(c => c.Save(It.IsAny<EMailAddress>()));
            this.emailAddressClientMock.Verify(c => c.Get(emailAddress.ObjectId));
        }

        [Test]
        public void CreateCompany()
        {
            var company = this.GetCompany();
            this.companyClientMock.Setup(c => c.Save(It.IsAny<Company>())).Returns(company.ObjectId);
            this.companyClientMock.Setup(c => c.Get(company.ObjectId)).Returns(company);

            var result = this.customerService.CreateCompany(
                company.Name,
                company.Address.AddressLine,
                company.Address.ZipCode,
                company.Address.City,
                company.Address.Country,
                company.Website);

            Assert.AreEqual(company.ObjectId, result.ObjectId);
            this.companyClientMock.Verify(c => c.Save(It.IsAny<Company>()));
            this.companyClientMock.Verify(c => c.Get(company.ObjectId));
        }

        [Test]
        public void CreatePerson()
        {
            var person = this.GetPerson();
            this.personClientMock.Setup(c => c.Save(It.IsAny<Person>())).Returns(person.ObjectId);
            this.personClientMock.Setup(c => c.Get(person.ObjectId)).Returns(person);

            var result = this.customerService.CreatePerson(
                person.FirstName,
                person.LastName,
                person.Employer,
                person.Address.AddressLine,
                person.Address.ZipCode,
                person.Address.City,
                person.Address.Country,
                person.PhoneNumbers,
                person.EMailAddresses);

            Assert.AreEqual(person.ObjectId, result.ObjectId);
            this.personClientMock.Verify(c => c.Save(It.IsAny<Person>()));
            this.personClientMock.Verify(c => c.Get(person.ObjectId));
        }

        [Test]
        public void DeletePerson()
        {
            var person = this.GetPerson();
            this.personClientMock.Setup(p => p.Remove(person));

            this.customerService.DeletePerson(person);

            this.personClientMock.Verify(p => p.Remove(person));
        }

        [Test]
        public void DeleteEMailAddress()
        {
            var emailAddress = this.GetEMailAddress();
            this.emailAddressClientMock.Setup(p => p.Remove(emailAddress));

            this.customerService.DeleteEMailAddress(emailAddress);

            this.emailAddressClientMock.Verify(p => p.Remove(emailAddress));
        }

        [Test]
        public void DeletePhoneNumber()
        {
            var phoneNumber = this.GetPhoneNumber();
            this.phoneNumberClientMock.Setup(p => p.Remove(phoneNumber));

            this.customerService.DeletePhoneNumber(phoneNumber);

            this.phoneNumberClientMock.Verify(p => p.Remove(phoneNumber));
        }

        [Test]
        public void DeleteCompany()
        {
            var company = this.GetCompany();
            this.companyClientMock.Setup(p => p.Remove(company));

            this.customerService.DeleteCompany(company);

            this.companyClientMock.Verify(p => p.Remove(company));
        }

        private Person GetPerson()
        {
            return new Person
                       {
                           ObjectId = Guid.Parse("227E3D9A-CE07-4FE3-A369-21147978E25C"),
                           Address =
                               new Address
                                   {
                                       ObjectId = Guid.Parse("D170010B-FA17-4001-9B6C-DA011D79F650"),
                                       AddressLine = "Apothekerweg 34",
                                       City = "Lausanne",
                                       Country = "Switzerland",
                                       ZipCode = "4002"
                                   },
                           FirstName = "Raul",
                           LastName = "Anjasson",
                           Employer =
                               new Company
                                   {
                                       ObjectId = Guid.Parse("166384D0-C847-4FA8-A6B2-2142C784B917"),
                                       Name = "HOLM AG"
                                   },
                           PhoneNumbers =
                               new Collection<PhoneNumber>
                                   {
                                       new PhoneNumber
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "C2FF5528-267C-4EEC-BFC2-AF7858B75294"),
                                               ContactType =
                                                   ContactType.Company,
                                               Number = "8539 29859 239"
                                           }
                                   },
                           EMailAddresses =
                               new Collection<EMailAddress>
                                   {
                                       new EMailAddress
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "85584DF1-0737-46FE-80EC-F1C936A51AEC"),
                                               Address = "w00t@d00d.com",
                                               ContactType =
                                                   ContactType.Private
                                           }
                                   }
                       };
        }

        private List<Person> GetPersons()
        {
            return new List<Person>
                       {
                           new Person
                               {
                                   ObjectId = Guid.Parse("E5C71CA6-D09A-4E0A-BF10-3CCCA13B6CA3"),
                                   Address =
                                       new Address
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "70947E3A-62BD-4410-B3FF-54E7C560EE3A"),
                                               AddressLine = "Bahnhofstrasse 12",
                                               City = "Zürich",
                                               Country = "Switzerland",
                                               ZipCode = "8001"
                                           },
                                   FirstName = "Hans",
                                   LastName = "Wurscht",
                                   Employer =
                                       new Company
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "104B331E-7672-42DB-9E4A-B8C84659CCC0"),
                                               Name = "Wurschwarenfabrik AG"
                                           }
                               },
                           new Person
                               {
                                   ObjectId = Guid.Parse("2D84E08A-6954-4BF8-B638-DB791BD28C8A"),
                                   Address =
                                       new Address
                                           {
                                               ObjectId =
                                                   Guid.Parse(
                                                       "095E0E84-5500-4316-B10F-AACBAB164B9B"),
                                               AddressLine = "Dorfplatz 1",
                                               City = "München",
                                               Country = "Germany",
                                               ZipCode = "23532"
                                           },
                                   FirstName = "Peter",
                                   LastName = "Fleischli"
                               }
                       };
        }

        private Company GetCompany()
        {
            return new Company
                       {
                           ObjectId = Guid.Parse("C22842F1-1C55-4FBE-B0BA-6D6B4EC67852"),
                           Name = "AIG",
                           Address =
                               new Address
                                   {
                                       ObjectId = Guid.Parse("C22842F1-1C55-4FBE-B0BA-6D6B4EC67852"),
                                       AddressLine = "Infinity Loop 1",
                                       City = "NYC",
                                       Country = "United States of America",
                                       ZipCode = "89232"
                                   },
                           Website = "http://aig.com"
                       };
        }

        private List<Company> GetCompanies()
        {
            return new List<Company>
                       {
                           new Company
                               {
                                   ObjectId = Guid.Parse("8E24DDC5-0D1C-420B-A2E2-D3E6B0CB8C02"),
                                   Name = "Meiers Daunenbetten GmbH"
                               },
                           new Company
                               {
                                   ObjectId = Guid.Parse("6C3D9FCC-155D-47EA-85C3-1CF471444793"),
                                   Name = "Flüeler Accounting",
                                   Website = "http://www.flueeler.ch"
                               }
                       };
        }

        private IEnumerable<string> GetCountries()
        {
            return
                CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                           .Select(ci => new RegionInfo(ci.LCID))
                           .GroupBy(ri => ri.TwoLetterISORegionName)
                           .Select(g => g.First().DisplayName)
                           .OrderBy(c => c);
        }

        private EMailAddress GetEMailAddress()
        {
            return new EMailAddress
                       {
                           ObjectId = Guid.Parse("A5C32866-7752-459E-BC2C-06C9B99F9281"),
                           Address = "ich.bin@lustig.ch",
                           ContactType = ContactType.Private
                       };
        }

        private List<EMailAddress> GetEMailAddresses()
        {
            return new List<EMailAddress>
                       {
                           new EMailAddress
                               {
                                   ObjectId =
                                       Guid.Parse(
                                           "C07B321C-B0A2-462C-8A64-FEC111213DEC"),
                                   Address = "hans@oracle.com",
                                   ContactType = ContactType.Company
                               },
                           new EMailAddress
                               {
                                   ObjectId =
                                       Guid.Parse(
                                           "24E72343-31DD-44EF-A6F2-331063ADA744"),
                                   Address = "hans.wurscht@google.com",
                                   ContactType = ContactType.Private
                               }
                       };
        }

        private PhoneNumber GetPhoneNumber()
        {
            return new PhoneNumber
                       {
                           ObjectId = Guid.Parse("3022C1E6-6C02-43F0-A471-1A7354F62970"),
                           Number = "89235892 29358",
                           ContactType = ContactType.Private
                       };
        }

        private List<PhoneNumber> GetPhoneNumbers()
        {
            return new List<PhoneNumber>
                       {
                           new PhoneNumber
                               {
                                   ObjectId =
                                       Guid.Parse("2EB2ADAB-01AC-4C63-9504-A2A28498F2CB"),
                                   Number = "9683496830",
                                   ContactType = ContactType.Company
                               },
                           new PhoneNumber
                               {
                                   ObjectId =
                                       Guid.Parse("8BC51D18-8C74-415B-9CDD-F3DB010F249D"),
                                   Number = "386 9834849489494",
                                   ContactType = ContactType.Private
                               }
                       };
        }
    }
}
