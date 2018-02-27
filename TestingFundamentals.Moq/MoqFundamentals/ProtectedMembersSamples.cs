using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture]
    public class ProtectedMembersSamples
    {
        private Mock<Person> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<Person>();
        }

        [TearDown]
        public void Clear()
        {
            _mock.Reset();
        }

        [Test]
        public void ProtectedMembersMethod()
        {
            _mock.Protected().SetupGet<int>("SSN").Returns(42);

            _mock.Protected().Setup<string>("Execute", ItExpr.IsAny<string>());
        }
    }
}