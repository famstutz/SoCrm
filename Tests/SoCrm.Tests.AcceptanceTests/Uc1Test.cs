namespace SoCrm.Tests.AcceptanceTests
{
    using System.IO;

    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [CodedUITest]
    public class Uc1Test
    {
        private UIMap map;
        private ApplicationUnderTest app;

        public UIMap UIMap
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
        public void MyTestInitialize()
        {
            this.app = ApplicationUnderTest.Launch(Path.Combine(Directory.GetCurrentDirectory(), @"App\SoCrm.Presentation.App.exe"));
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            this.app.Close();
        }

        [TestMethod]
        public void RunUc1Test()
        {
            this.UIMap.OpenAuthentication();
            this.UIMap.EnterCredentials();
            this.UIMap.LogOn();
        }
    }
}
