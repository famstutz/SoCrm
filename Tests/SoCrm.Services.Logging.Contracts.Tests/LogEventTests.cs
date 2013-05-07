namespace SoCrm.Services.Logging.Contracts.Tests
{
    using System;

    using NUnit.Framework;

    using SoCrm.Tests.Common;

    [TestFixture]
    public class LogEventTests
    {
        [Test]
        public void Constructor()
        {
            var logEvent = new LogEvent();

            Assert.IsNotNull(logEvent);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var logEvent = new LogEvent();

            AssertExtensions.IsDefault(logEvent.Message);
            AssertExtensions.IsDefault(logEvent.Severity);
            AssertExtensions.IsDefault(logEvent.TimeStamp);
        }

        [Test]
        public void SetMessage()
        {
            var logEvent = new LogEvent();
            var message = "Test 1, 2, 3";
            logEvent.Message = message;

            Assert.AreEqual(message, logEvent.Message);
        }

        [Test]
        public void SetSeverity()
        {
            var logEvent = new LogEvent();
            var severity = Severity.Warning;
            logEvent.Severity = severity;

            Assert.AreEqual(severity, logEvent.Severity);
        }

        [Test]
        public void SetTimeStamp()
        {
            var logEvent = new LogEvent();
            var timeStamp = DateTime.Now;
            logEvent.TimeStamp = timeStamp;

            Assert.AreEqual(timeStamp, logEvent.TimeStamp);
        }
    }
}
