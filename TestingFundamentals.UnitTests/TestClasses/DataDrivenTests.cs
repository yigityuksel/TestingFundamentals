using System;
using NUnit.Framework;
using TestingFundamentals.UnitTests.Classes;

namespace TestingFundamentals.UnitTests.TestClasses
{
    [TestFixture]
    public class DataDrivenTests
    {
        private BankAccount _bankAccount;

        [SetUp]
        public void SetUp()
        {
            _bankAccount = new BankAccount(100);
        }

        [Test]
        [TestCase(50, true, 50)]
        [TestCase(100, true, 0)]
        [TestCase(1000, false, 100)]
        public void TestMultipleWithDrawalScenarios(int amountToWithdraw, bool shouldSucceed, int expectedBalance)
        {
            var result = _bankAccount.Withdraw(amountToWithdraw);

            //Warn.If(!result, "Failed For Some Reason");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(shouldSucceed));
                Assert.That(expectedBalance, Is.EqualTo(_bankAccount.Balance));
            });

        }

    }
}