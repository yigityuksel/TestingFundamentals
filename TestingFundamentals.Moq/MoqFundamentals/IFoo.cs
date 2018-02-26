using System.Threading;
using Moq;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    public interface IFoo
    {
        bool DoSomething(string value);
        string ProcessString(string value);
        bool TryParse(string value, out string outputValue);
        bool Submit(ref Bar bar);
        int GetCount();
        bool Add(int amount);

        string Name { get; set; }
        IBaz SomeBaz { get; set; }
        int SomeOtherPropery { get; set; }
    }
}