using Moq;
using NUnit.Framework;
using TestingFundamentals.Moq.Classes;
using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.TestClasses
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _bankAccount;

        [Test]
        public void DepositTest()
        {
            var log = new Mock<ILog>();

            _bankAccount = new BankAccount(log.Object)
            {
                Balance = 100
            };

            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

    }
}