using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.Classes
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
            _log.Write($"Depositing {amount}");
            Balance += amount;
        }
    }
}
