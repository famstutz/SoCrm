namespace SoCrm.Presentation.Core.Tests
{
    using System;

    using NUnit.Framework;

    [TestFixture]
    public class CommandModelTests
    {
        [Test]
        public void Constructor()
        {
            var commandModel = new CommandModel(this.Stub);

            Assert.IsNotNull(commandModel);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ArgumentNullException()
        {
            var commandModel = new CommandModel(null);
        }

        [Test]
        public void AddCanExecuteChanged()
        {
            var commandModel = new CommandModel(this.Stub);

            commandModel.CanExecuteChanged += this.Stub;
            commandModel.CanExecuteChanged -= this.Stub;
        }

        [Test]
        public void CanExecute()
        {
            var commandModel = new CommandModel(this.Stub);

            commandModel.CanExecute(null);
        }

        private void Stub(object sender, EventArgs e)
        {
        }

        private void Stub(object obj)
        {
        }
    }
}
