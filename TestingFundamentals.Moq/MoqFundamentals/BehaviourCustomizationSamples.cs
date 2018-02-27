using Moq;
using NUnit.Framework;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture]
    public class BehaviourCustomizationSamples
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

            _mock = new Mock<IFoo>(MockBehavior.Strict);//requires all methods should setup!

            _mock.Setup(f => f.DoSomething("abc")).Returns(true);

            _mock.Object.DoSomething("abc");

            ////////////////////////////////////

            _mock = new Mock<IFoo>()
            {
                DefaultValue = DefaultValue.Mock
            };

            var baz = _mock.Object.SomeBaz;
            var bazMock = Mock.Get(baz);
            bazMock.SetupGet(f => f.Name).Returns("abc");

            /////////////////////////////////////

            var mockRepository = new MockRepository(MockBehavior.Strict)
            {
                DefaultValue = DefaultValue.Mock
            };

            var fooMock = mockRepository.Create<IFoo>();
            var otherMock = mockRepository.Create<IBaz>(MockBehavior.Loose);

            mockRepository.Verify();

        }
    }
}