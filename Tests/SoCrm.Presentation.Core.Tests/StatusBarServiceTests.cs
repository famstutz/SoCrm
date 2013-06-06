namespace SoCrm.Presentation.Core.Tests
{
    using System;

    using NUnit.Framework;

    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Tests.Common;

    [TestFixture]
    public class StatusBarServiceTests
    {
        [Test]
        public void Constructor()
        {
            var statusBarService = new StatusBarService();
            
            Assert.IsNotNull(statusBarService);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var statusBarService = new StatusBarService();

            AssertExtensions.IsDefault(statusBarService.LastStatus);
        }

        [Test]
        public void SetDateTime()
        {
            var dateTime = DateTime.Now;
            var statusBarService = new StatusBarService();

            statusBarService.DateTime = dateTime;

            Assert.AreEqual(dateTime, statusBarService.DateTime);
        }

        [Test]
        public void SetLastStatus()
        {
            var status = "Test, 1, 2, 3.";
            var statusBarService = new StatusBarService();

            statusBarService.LastStatus = status;

            Assert.AreEqual(status, statusBarService.LastStatus);
        }
    }
}
