using System;
using TestingFundamentals.Moq.Interfaces;

namespace TestingFundamentals.Moq.Classes
{
    public class Doctor
    {
        public int TimesCured { get; private set; }
        public int AbductionObserved { get; private set; }
        public Doctor(IAnimal animal)
        {
            animal.FallsIll += (sender, args) =>
            {
                Console.WriteLine("I will cure you");
                TimesCured++;
            };

            animal.AbductedByAlien += (galaxy, returned) =>
            {
                Console.WriteLine("Abduction Observerd");
                AbductionObserved++;
            };
        }
    }
}