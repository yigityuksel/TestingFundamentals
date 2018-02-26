using System;
using TestingFundamentals.IntegrationTesting.Interfaces;

namespace TestingFundamentals.IntegrationTesting.Classes
{
    public class ConsoleLog : ILog
    {
        public bool Write(string message)
        {
            Console.WriteLine(message);
            return true;
        }
    }
}