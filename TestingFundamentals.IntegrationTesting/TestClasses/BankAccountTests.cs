using NUnit.Framework;
using TestingFundamentals.IntegrationTesting.Classes;
using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.TestClasses
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount _bankAccount;

        [Test]
        public void DepositIntegrationTest()
        {
            _bankAccount = new BankAccount(new ConsoleLog())
            {
                Balance = 100
            };

            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositIntegrationTestWithFake()
        {
            var log = new NullLog();
            _bankAccount = new BankAccount(log) { Balance = 100 };

            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositIntegrationTestWithStub()
        {
            var log = new NullLogWithResult(true);
            _bankAccount = new BankAccount(log) { Balance = 100 };

            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositIntegrationTestWithDynamicFake()
        {
            var log = Null<ILog>.Instance;
            _bankAccount = new BankAccount(log) { Balance = 100 };

            _bankAccount.Deposit(100);
            Assert.That(_bankAccount.Balance, Is.EqualTo(200));
        }

        [Test]
        public void DepositIntegrationTestWithMock()
        {
            var log = new LogMock(true);
            _bankAccount = new BankAccount(log) { Balance = 100 };

            _bankAccount.Deposit(100);
            Assert.Multiple(() =>
            {
                Assert.That(_bankAccount.Balance, Is.EqualTo(200));
                Assert.That(log.MethodCallCount[nameof(LogMock.Write)], Is.EqualTo(1));
            });
        }

    }
}