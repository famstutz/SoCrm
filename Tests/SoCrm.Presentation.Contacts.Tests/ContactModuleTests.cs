namespace SoCrm.Presentation.Contacts.Tests
{
    using Microsoft.Practices.Unity;

    using NUnit.Framework;

    using SoCrm.Presentation.Contacts;
    using SoCrm.Presentation.Contacts.Contact;
    using SoCrm.Presentation.Contacts.ContactList;
    using SoCrm.Presentation.Contacts.CreateContact;
    using SoCrm.Presentation.Contacts.Customer;

    [TestFixture]
    public class ContactModuleTests
    {
        [Test]
        public void Constructor()
        {
            var contactModule = new ContactModule();

            Assert.IsNotNull(contactModule);
        }

        [Test]
        public void Register()
        {
            var unityContainer = new UnityContainer();
            var contactModule = new ContactModule();

            contactModule.Register(unityContainer);

            Assert.IsTrue(unityContainer.IsRegistered<IContactController>());
            Assert.IsTrue(unityContainer.IsRegistered<IContactListViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<ICreateContactViewModel>());
            Assert.IsTrue(unityContainer.IsRegistered<IContactService>());
            Assert.IsTrue(unityContainer.IsRegistered<ICustomerService>());
        }
    }
}
