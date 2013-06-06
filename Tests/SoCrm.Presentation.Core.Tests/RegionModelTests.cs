namespace SoCrm.Presentation.Core.Tests
{
    using NUnit.Framework;

    using SoCrm.Presentation.Core.Tests.Testables;
    using SoCrm.Tests.Common;

    [TestFixture]
    public class RegionModelTests
    {
        [Test]
        public void Constructor()
        {
            var regionModel = new RegionModel();

            Assert.IsNotNull(regionModel);
        }

        [Test]
        public void PropertiesDefaultValues()
        {
            var regionModel = new RegionModel();

            AssertExtensions.IsDefault(regionModel.Context);
        }

        [Test]
        public void SetContext()
        {
            var context = new TestableViewModel();
            var regionModel = new RegionModel();
            regionModel.PropertyChanged += (sender, args) => { };

            regionModel.Context = context;

            Assert.AreEqual(context, regionModel.Context);
        }
        
    }
}
