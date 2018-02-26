using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestingFundamentals.UnitTests.Fundamentals
{
    [TestFixture]
    public class WarningFixture
    {
        [Test]
        public void Warnings()
        {

            Warn.If(2+2!=5);
            Warn.If(2+2, Is.Not.EqualTo(5));
            Warn.If(() => 2+2, Is.Not.EqualTo(5).After(2000));

            Warn.Unless(2 + 2 != 5);
            Warn.Unless(2 + 2, Is.Not.EqualTo(5));
            Warn.Unless(() => 2 + 2, Is.Not.EqualTo(5).After(2000));

            Assert.Warn("I am warning you");
        }
    }
}