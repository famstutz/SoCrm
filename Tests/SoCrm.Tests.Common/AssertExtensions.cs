namespace SoCrm.Tests.Common
{
    using NUnit.Framework;

    public static class AssertExtensions
    {
        /// <summary>
        /// Determines whether the specified assert is default.
        /// </summary>
        /// <param name="value">The value.</param>
        public static void IsDefault<T>(T value)
        {
            Assert.AreEqual(default(T), value);
        }
    }
}
