using NUnit.Framework;
using NSubstitute;
using System.Collections.Generic;

namespace cs_mocking_examples
{
    public class MyList<T> : List<T>
    {
        public virtual long GetSize()
        {
            return this.Count;
        }
    }

    public interface ICounter
    {
        int currentIndex();
    }

    public interface IFoo
    {
        void SayHello(string to);
    }

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Mocking_an_interface()
        {
            // arrange
            var counter = Substitute.For<ICounter>();
            counter.currentIndex().Returns(4);
            int expectedLength = 4;

            // act
            long result = counter.currentIndex();

            // assert
            Assert.AreEqual(expectedLength, result);
        }

        [Test]
        public void Mocking_a_class()
        {
            // arrange
            var salmons = Substitute.For<MyList<string>>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");
            salmons.GetSize().Returns(3);
            int expectedLength = 4;

            // act
            long result = salmons.GetSize();
            //long result = salmons.Count;

            // assert
            Assert.AreEqual(expectedLength, result);
        }

        [Test]
        public  void    Verification_testing()
        {
            var counter = 0;
            var foo = Substitute.For<IFoo>();
            foo.When(x => x.SayHello("World"))
                .Do(x => counter++);

            foo.SayHello("World");
            foo.SayHello("World");
            Assert.AreEqual(2, counter);
        }

        [Test]
        public void Verification_testing_updated_version()
        {
            // With this approach, there is no need to use the When and Do methods
            // But, the When and Do apporach is useful triggering other events
            // when something occurs in the test

            // arrange
            var foo = Substitute.For<IFoo>();

            // act
            foo.SayHello("World");

            // assert
            foo.Received(2).SayHello(Arg.Any<string>());
        }
    }
}