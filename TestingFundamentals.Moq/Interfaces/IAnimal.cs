using System;
using TestingFundamentals.Moq.Delegate;

namespace TestingFundamentals.Moq.Interfaces
{
    public interface IAnimal
    {
        event EventHandler FallsIll;
        void Stumble();

        event AlienAbductionEventHandler AbductedByAlien;
    }
}