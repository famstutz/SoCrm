namespace SoCrm.Core.Contracts.Tests
{
    using System;

    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class DomainObjectTests
    {
        [Test]
        public void Constructor()
        {
            var domainObject = new DomainObject();

            Assert.IsNotNull(domainObject);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var domainObject = new DomainObject();

            AssertExtensions.IsDefault(domainObject.ObjectId);
            AssertExtensions.IsDefault(domainObject.CreationTimeStamp);
            AssertExtensions.IsDefault(domainObject.LastUpdateTimeStamp);
        }

        [Test]
        public void SetObjectId()
        {
            var domainObject = new DomainObject();
            var guid = Guid.NewGuid();
            domainObject.ObjectId = guid;

            Assert.AreEqual(guid, domainObject.ObjectId);
        }

        [Test]
        public void SetCreationTimeStamp()
        {
            var domainObject = new DomainObject();
            var dateTime = DateTime.Now;
            domainObject.CreationTimeStamp = dateTime;

            Assert.AreEqual(dateTime, domainObject.CreationTimeStamp);
        }

        [Test]
        public void SetLastUpdateTimeStamp()
        {
            var domainObject = new DomainObject();
            var dateTime = DateTime.Now;
            domainObject.LastUpdateTimeStamp = dateTime;

            Assert.AreEqual(dateTime, domainObject.LastUpdateTimeStamp);
        }
    }
}
