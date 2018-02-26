using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TestingFundamentals.Moq.MoqFundamentals
{
    [TestFixture]
    public class MethodAndPropertySamples
    {
        private Mock<IFoo> _mock;

        [SetUp]
        public void SetUp()
        {
            _mock = new Mock<IFoo>();
        }

        [TearDown]
        public void Clear()
        {
            _mock.Reset();
        }

        [Test]
        public void OrdinaryMethodCalls()
        {
            _mock.Setup(foo => foo.DoSomething("ping")).Returns(true);
            //mock.Setup(foo => foo.DoSomething("pong")).Returns(false);

            _mock.Setup(foo => foo.DoSomething(It.IsIn("pong", "foo"))).Returns(false);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(_mock.Object.DoSomething("ping"));
                Assert.IsFalse(_mock.Object.DoSomething("pong"));
                Assert.IsFalse(_mock.Object.DoSomething("foo"));
            });

        }

        [Test]
        public void ArgumentDependentMatching()
        {
            _mock.Setup(foo => foo.DoSomething(It.IsAny<string>()))
                .Returns(false);

            _mock.Setup(foo => foo.Add(It.Is<int>(x => x % 2 == 0)))
                .Returns(true);

            _mock.Setup(foo => foo.Add(It.IsInRange<int>(1, 10, Range.Inclusive)))
                .Returns(false);

            _mock.Setup(foo => foo.DoSomething(It.IsRegex("[a-z]+")))
                .Returns(false);
        }

        [Test]
        public void OutAndRefArguments()
        {
            string requiredOutput = "";

            _mock.Setup(foo => foo.TryParse("ping", out requiredOutput))
                .Returns(true);

            string result;

            Assert.Multiple(() =>
            {
                Assert.IsTrue(_mock.Object.TryParse("ping", out result));
                Assert.That(result, Is.EqualTo(requiredOutput));

                var thisShouldBeFalse = _mock.Object.TryParse("pong", out result);
                Console.WriteLine(thisShouldBeFalse);
                Console.WriteLine(result);
            });

            var bar = new Bar() { Name = "abc" };
            _mock.Setup(foo => foo.Submit(ref bar)).Returns(true);

            Assert.That(_mock.Object.Submit(ref bar), Is.EqualTo(true));

            var someOtherBar = new Bar() { Name = "abc" };
            Assert.IsFalse(_mock.Object.Submit(ref someOtherBar));

        }

        [Test]
        public void ProcessStringTest()
        {
            _mock.Setup(foo => foo.ProcessString(It.IsAny<string>()))
                .Returns((string s) => s.ToLowerInvariant());//whenever mock object used, return lowervariant of string

            Assert.Multiple(() =>
            {
                Assert.That(_mock.Object.ProcessString("ABC"), Is.EqualTo("abc"));
            });
        }

        [Test]
        public void GetCountTest()
        {
            var calls = 0;

            _mock.Setup(foo => foo.GetCount())
                .Returns(() => calls)
                .Callback(() => ++calls);

            _mock.Object.GetCount();
            _mock.Object.GetCount();

            Assert.Multiple(() =>
            {
                Assert.That(_mock.Object.GetCount(), Is.EqualTo(2));
            });
        }

        [Test]
        public void DoSomethingTest()
        {
            _mock.Setup(foo => foo.DoSomething("kill"))
                .Throws<InvalidOperationException>();

            Assert.Throws<InvalidOperationException>(
                () => _mock.Object.DoSomething("kill")
            );
        }

        [Test]
        public void ExceptionTest()
        {
            _mock.Setup(foo => foo.DoSomething("null"))
                .Throws(new ArgumentException("cmd"));

            Assert.Throws<ArgumentException>(
                () => { _mock.Object.DoSomething(null); },
                "cmd"
            );
        }

        [Test]
        public void PropertiesTests()
        {
            _mock.Setup(foo => foo.Name).Returns("bar");

            _mock.Object.Name = "will not be assigned";
            Assert.That(_mock.Object.Name, Is.EqualTo("bar"));

            _mock.Setup(foo => foo.SomeBaz.Name).Returns("hello");
            Assert.That(_mock.Object.SomeBaz.Name, Is.EqualTo("hello"));

            //In here we defined, someone can set property.
            bool setterCalled = false;
            _mock.SetupSet(foo =>
            {
                foo.Name = It.IsAny<string>();
            })
                .Callback<string>(value =>
                {
                    setterCalled = true;

                });

            _mock.Object.Name = "def"; //its now valid
            _mock.VerifySet(foo => { foo.Name = "def"; }, Times.AtLeastOnce);

        }

        [Test]
        public void SetupAllPropertiesTests()
        {

            // _mock.SetupProperty(f => f.Name);

            _mock.SetupAllProperties();//means we can set all properties.

            IFoo foo = _mock.Object;
            foo.Name = "abc";
            Assert.That(_mock.Object.Name, Is.EqualTo("abc"));

            foo.Name = "abcd";
            foo.SomeOtherPropery = 1234;

            Assert.That(_mock.Object.SomeOtherPropery, Is.EqualTo(1234));

        }

    }
}