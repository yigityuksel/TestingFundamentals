using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    //STUB
    public class NullLogWithResult : ILog
    {
        private readonly bool _expectedResult;

        public NullLogWithResult(bool expectedResult)
        {
            this._expectedResult = expectedResult;
        }

        public bool Write(string message)
        {
            return _expectedResult;
        }
    }
}