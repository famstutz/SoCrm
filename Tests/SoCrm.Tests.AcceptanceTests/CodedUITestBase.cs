namespace SoCrm.Tests.AcceptanceTests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [CodedUITest]
    public abstract class CodedUITestBase
    {
        private UIMap map;
        private ApplicationUnderTest app;

        protected UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.app = ApplicationUnderTest.Launch(Path.Combine(Directory.GetCurrentDirectory(), @"App\SoCrm.Presentation.App.exe"));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            this.app.Close();
        }

        [TestMethod]
        public abstract void Execute();
    }
}
