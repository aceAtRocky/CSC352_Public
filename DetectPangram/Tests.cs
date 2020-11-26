namespace Solution
{
    using NUnit.Framework;

    using System;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void SampleTests()
        {
            Assert.AreEqual(true, Kata.IsPangram("The quick brown fox jumps over the lazy dog."));
        }
    }
}
