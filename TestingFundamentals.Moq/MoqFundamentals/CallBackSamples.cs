using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestingFundamentals.Moq.Classes;
using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture()]
    public class CallBackSamples
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
        public void CallBackMethod()
        {
            int x = 0;
            _mock.Setup(foo => foo.DoSomething("ping")).Returns(true).Callback(() => { x++; });
            _mock.Object.DoSomething("ping");
            Assert.That(x, Is.EqualTo(1));

            _mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true).Callback((string s) => x += s.Length);

            _mock.Setup(foo => foo.DoSomething(It.IsAny<string>())).Returns(true).Callback<string>(s => x += s.Length);

            _mock.Setup(foo => foo.DoSomething("pong")).Callback(() => Console.WriteLine("Before")).Returns(false).Callback(() => Console.WriteLine("After"));

            _mock.Object.DoSomething("pong");
        }
    }
}