using System.Collections.Generic;
using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    public class LogMock : ILog
    {
        private readonly bool _expectedResult;
        public Dictionary<string, int> MethodCallCount { get; private set ; }

        public LogMock(bool expectedResult)
        {
            _expectedResult = expectedResult;
            MethodCallCount = new Dictionary<string, int>();
        }


        private void AddOrIncrement(string methodName)
        {
            if (MethodCallCount.ContainsKey(methodName))
                MethodCallCount[methodName]++;
            else
                MethodCallCount.Add(methodName, 1);
        }

        public bool Write(string message)
        {
            AddOrIncrement(nameof(Write));
            return _expectedResult;
        }
    }
}