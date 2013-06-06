namespace SoCrm.Presentation.Core.Tests
{
    using Microsoft.Practices.Unity;

    using Moq;

    using NUnit.Framework;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Presentation.Core.StatusBar;
    using SoCrm.Presentation.Core.Tests.Testables;

    [TestFixture]
    public class ControllerBaseTests
    {
        private IUnityContainer unityContainer;

        private Mock<IStatusBarService> statusBarServiceMock;

        private Mock<IRegion> regionMock;

        [SetUp]
        public void SetUp()
        {
            this.statusBarServiceMock = new Mock<IStatusBarService>();
            this.regionMock = new Mock<IRegion>();

            this.unityContainer = new UnityContainer();
            this.unityContainer.RegisterInstance(this.statusBarServiceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.unityContainer = null;
            this.regionMock = null;
            this.statusBarServiceMock = null;
        }

        [Test]
        public void Constructor()
        {
            var controllerBase = new TestableController(this.unityContainer, this.regionMock.Object);

            Assert.IsNotNull(controllerBase);
        }

        [Test]
        public void SetLastStatus()
        {
            var status = "Test, 1, 2, 3.";
            this.statusBarServiceMock.SetupSet(s => s.LastStatus = status).Verifiable();
            var controllerBase = new TestableController(this.unityContainer, this.regionMock.Object);

            controllerBase.SetLastStatus(status);

            this.statusBarServiceMock.Verify();
        }

        [Test]
        public void ClearMainRegion()
        {
            this.regionMock.SetupSet(r => r.Context = null).Verifiable();
            var controllerBase = new TestableController(this.unityContainer, this.regionMock.Object);

            controllerBase.ClearMainRegion();

            this.regionMock.Verify();
        }
    }
}
