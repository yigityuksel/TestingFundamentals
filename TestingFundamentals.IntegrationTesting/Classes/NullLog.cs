using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    public class NullLog : ILog
    {
        public bool Write(string message)
        {
            return true;
        }
    }
}