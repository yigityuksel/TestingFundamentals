using System;
using NUnit.Framework;
using TestingFundamentals.UnitTests.Classes;

namespace TestingFundamentals.UnitTests.TestClasses
{

    // AAA - Arrange - Act - Assert

    [TestFixture]
    public class BankAccountTests
    {

        private BankAccount _bankAccount;

        [SetUp]
        public void SetUp()
        {
            //arrange
            _bankAccount = new BankAccount(100);
        }

        [Test]
        public void BackShouldIncreaseOnPositiveDeposit()
        {
            //act
            _bankAccount.Deposit(100);

            //assert
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

        [Test]
        public void MultipleAssertionTests()
        {
            _bankAccount.Withdraw(100);

            //in testing at first assertion if fails, the other assertions won't work.
            //Assert.That(_bankAccount.Balance, Is.EqualTo(0));
            //Assert.That(_bankAccount.Balance, Is.LessThan(1));

            Assert.Multiple(() =>
            {
                Assert.That(_bankAccount.Balance, Is.EqualTo(0));
                Assert.That(_bankAccount.Balance, Is.LessThan(1));
            });
        }

        [Test]
        public void BankAccountShouldThrowOnNonPositiveAmount()
        {
            var exception = Assert.Throws<ArgumentException>(
                 () => _bankAccount.Deposit(-1)
                 );

            StringAssert.StartsWith("Deposit amount must be positive", exception.Message);
        }

    }
}
