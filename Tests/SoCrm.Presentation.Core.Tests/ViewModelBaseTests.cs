namespace SoCrm.Presentation.Core.Tests
{
    using NUnit.Framework;

    using SoCrm.Presentation.Core.Tests.Testables;

    [TestFixture]
    public class ViewModelBaseTests
    {
        private bool isTested = false;

        [Test]
        public void Contructor()
        {
            var testableViewModel = new TestableViewModel();

            Assert.IsNotNull(testableViewModel);
        }

        [Test]
        public void OnPropertyChanged()
        {
            var testableViewModel = new TestableViewModel();
            testableViewModel.PropertyChanged += (sender, args) => this.isTested = true;

            testableViewModel.Value = "Test, 1, 2, 3";

            Assert.IsTrue(this.isTested);
        }
    }
}
