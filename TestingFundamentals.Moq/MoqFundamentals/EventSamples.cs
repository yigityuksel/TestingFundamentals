using System;
using Moq;
using NUnit.Framework;
using TestingFundamentals.Moq.Classes;
using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture]
    public class EventSamples
    {
        private Mock<IAnimal> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IAnimal>();
        }

        [TearDown]
        public void Clear()
        {
            _mock.Reset();
        }

        [Test]
        public void MyMethod()
        {
            var doctor = new Doctor(_mock.Object);

            _mock.Raise(a => a.FallsIll += null, new EventArgs());

            Assert.That(doctor.TimesCured, Is.EqualTo(1));

            _mock.Setup(a => a.Stumble()).Raises(a => a.FallsIll += null, new EventArgs());

            _mock.Object.Stumble();

            Assert.That(doctor.TimesCured, Is.EqualTo(2));
            
            _mock.Raise(a => a.AbductedByAlien += null, 42 , true);

            Assert.That(doctor.AbductionObserved, Is.EqualTo(1));

        }

    }
}