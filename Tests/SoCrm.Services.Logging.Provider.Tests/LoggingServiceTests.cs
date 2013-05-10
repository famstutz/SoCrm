namespace SoCrm.Services.Logging.Provider.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Services.Logging.Contracts;
    using SoCrm.Services.Logging.Provider.LogEventPersistence;

    [TestFixture]
    public class LoggingServiceTests
    {
        private Mock<IPersistenceServiceOf_LogEvent> logEventClientMock;

        private LoggingService loggingService;

        [SetUp]
        public void SetUp()
        {
            this.logEventClientMock = new Mock<IPersistenceServiceOf_LogEvent>();
            this.loggingService = new LoggingService(this.logEventClientMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.loggingService = null;
            this.logEventClientMock = null;
        }

        [Test]
        public void Constructor()
        {
            Assert.IsNotNull(this.loggingService);
        }

        [Test]
        public void GetAllLogEvents()
        {
            var logEventList = new List<LogEvent> { this.GetLogEvent() };
            this.logEventClientMock.Setup(u => u.GetAll()).Returns(logEventList);

            var result = this.loggingService.GetAllLogEvents();

            CollectionAssert.AreEqual(logEventList, result);
            this.logEventClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void GetAllSeverities()
        {
            var roles = Enum.GetValues(typeof(Severity)).Cast<Severity>();

            var result = this.loggingService.GetAllSeverities();

            CollectionAssert.AreEqual(roles, result);
        }

        [Test]
        public void GetLogEventByObjectId()
        {
            var logEvent = this.GetLogEvent();
            this.logEventClientMock.Setup(u => u.Get(logEvent.ObjectId)).Returns(logEvent);

            var result = this.loggingService.GetLogEventByObjectId(logEvent.ObjectId);

            Assert.AreEqual(logEvent, result);
            this.logEventClientMock.Verify(u => u.Get(logEvent.ObjectId));
        }

        [Test]
        public void GetLogEventsBySeverity()
        {
            var logEventList = new List<LogEvent> { this.GetLogEvent() };
            this.logEventClientMock.Setup(u => u.GetAll()).Returns(logEventList);

            var result = this.loggingService.GetLogEventsBySeverity(Severity.Warning);

            CollectionAssert.AreEqual(logEventList, result);
            this.logEventClientMock.Verify(u => u.GetAll());
        }

        [Test]
        public void LogEvent()
        {
            var logEvent = this.GetLogEvent();
            this.logEventClientMock.Setup(c => c.Save(It.IsAny<LogEvent>())).Returns(logEvent.ObjectId);
            this.logEventClientMock.Setup(c => c.Get(logEvent.ObjectId)).Returns(logEvent);

            var result = this.loggingService.LogEvent(logEvent.Message, logEvent.Severity, logEvent.TimeStamp);

            Assert.AreEqual(logEvent.ObjectId, result.ObjectId);
            this.logEventClientMock.Verify(c => c.Save(It.IsAny<LogEvent>()));
            this.logEventClientMock.Verify(c => c.Get(logEvent.ObjectId));
        }

        private LogEvent GetLogEvent()
        {
            return new LogEvent
            {
                ObjectId = Guid.Parse("84594C6D-4DCE-497F-B7DF-3ED714D50B0E"),
                Message = "Event happened.",
                Severity = Severity.Warning,
                TimeStamp = DateTime.Now
            };
        }
    }
}
