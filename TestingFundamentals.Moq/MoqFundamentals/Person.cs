namespace TestingFundamentals.Moq.MoqFundamentals
{
    public abstract class Person
    {
        protected int SSN { get; set; }
        protected abstract void Execute(string cmd);
    }
}