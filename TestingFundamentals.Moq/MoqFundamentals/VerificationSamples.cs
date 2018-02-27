using System;
using Moq;
using NUnit.Framework;
using TestingFundamentals.Moq.Classes;
using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture]
    public class VerificationSamples
    {
        private Mock<IFoo> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IFoo>();
        }

        [TearDown]
        public void Clear()
        {
            _mock.Reset();
        }

        [Test]
        public void VerificationMethod()
        {
            var consumer = new Consumer(_mock.Object);

            //consumer.Hello();

            _mock.Verify(foo => foo.DoSomething("ping"), Times.AtLeastOnce);

            _mock.Verify(foo => foo.DoSomething("pong"), Times.Never);

            _mock.VerifyGet(foo => foo.Name);

            _mock.VerifySet(foo => foo.SomeOtherPropery = It.IsInRange(100, 200, Range.Exclusive));

        }
    }
}