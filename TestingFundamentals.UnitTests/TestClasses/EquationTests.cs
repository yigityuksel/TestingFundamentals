using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestingFundamentals.UnitTests.TestDoubles;

namespace TestingFundamentals.UnitTests.TestClasses
{
    [TestFixture]
    public class EquationTests
    {
        [Test]
        public void Test()
        {
            var result = Solve.Quadratic(1, 10, 16);
            Assert.That(result.Item1, Is.EqualTo(-2));
        }

        [Test]
        public void Test2()
        {
            Assert.Throws<Exception>(() => Solve.Quadratic(1, 1, 1));
        }


    }
}