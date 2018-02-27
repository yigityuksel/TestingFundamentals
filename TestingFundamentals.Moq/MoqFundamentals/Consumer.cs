namespace TestingFundamentals.Moq.MoqFundamentals
{
    public class Consumer
    {
        private IFoo foo;

        public Consumer(IFoo foo)
        {
            this.foo = foo;
        }

        public void Hello()
        {
            foo.DoSomething("ping");
            var name = foo.Name;
            foo.SomeOtherPropery = 123;
        }
    }
}