namespace SoCrm.Services.Contacts.Provider
{
    using NUnit.Framework;

    [TestFixture]
    public class ContactServiceTests
    {
        [Test]
        public void Constructor()
        {
            var contactService = new ContactService();
            
            Assert.IsNotNull(contactService);
        }
    }
}
