using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    public class BankAccount
    {
        private readonly ILog _log;

        public int Balance { get; set; }

        public BankAccount(ILog log)
        {
            _log = log;
        }

        public void Deposit(int amount)
        {
            if (_log.Write($"Depositing {amount}"))
                Balance += amount;
        }

    }
}
