namespace SoCrm.Presentation.Core.Tests
{
    using System.Windows;

    using NUnit.Framework;

    using SoCrm.Presentation.Core.Helpers;

    [TestFixture]
    public class PasswordBoxHelperTests
    {
        [Test]
        public void BoundPassword()
        {
            var property = PasswordBoxHelper.BoundPassword;

            Assert.IsInstanceOf<DependencyProperty>(property);
        }

        [Test]
        public void BindPassword()
        {
            var property = PasswordBoxHelper.BindPassword;

            Assert.IsInstanceOf<DependencyProperty>(property);
        }

        [Test]
        public void SetBindPassword()
        {
            var dependencyObject = new DependencyObject();
            var value = true;

            PasswordBoxHelper.SetBindPassword(dependencyObject, value);

            Assert.AreEqual(dependencyObject.GetValue(PasswordBoxHelper.BindPassword), value);
        }

        [Test]
        public void GetBindPassword()
        {
            var dependencyObject = new DependencyObject();
            var value = true;

            PasswordBoxHelper.SetBindPassword(dependencyObject, value);

            Assert.AreEqual(PasswordBoxHelper.GetBindPassword(dependencyObject), value);
        }

        [Test]
        public void SetBoundPassword()
        {
            var dependencyObject = new DependencyObject();
            var value = "test";

            PasswordBoxHelper.SetBoundPassword(dependencyObject, value);

            Assert.AreEqual(dependencyObject.GetValue(PasswordBoxHelper.BoundPassword), value);
        }

        [Test]
        public void GetBoundPassword()
        {
            var dependencyObject = new DependencyObject();
            var value = "test";

            PasswordBoxHelper.SetBoundPassword(dependencyObject, value);

            Assert.AreEqual(PasswordBoxHelper.GetBoundPassword(dependencyObject), value);
        }
    }
}
