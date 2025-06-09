using Xunit;
using NSubstitute;
using System.Collections.Generic;
using cs_mocking_examples_library;

namespace cs_mocking_examples
{

    public interface ICounter
    {
        int currentIndex();
        int Foobar(string msg);
    }

    public interface IFoo
    {
        void SayHello(string to);
    }

    public class Tests
    {
        [Fact]
        public void Mocking_an_interface()
        {
            // arrange
            var counter = Substitute.For<ICounter>();
            counter.currentIndex().Returns(4);
            counter.Foobar("Hello").Returns(3);
            int expectedLength = 4;

            // act
            long result = counter.currentIndex();
            result = counter.Foobar("Hellox");

            // assert
            Assert.Equal(expectedLength, result);
        }

        [Fact]
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
            Assert.Equal(expectedLength, result);
        }

        [Fact]
        public  void    Verification_testing()
        {
            var counter = 0;
            var foo = Substitute.For<IFoo>();
            foo.When(x => x.SayHello("World"))
                .Do(x => counter++);

            foo.SayHello("World");
            foo.SayHello("World");
            Assert.Equal(2, counter);
        }

        [Fact]
        public void Verification_testing_updated_version()
        {
            // With this approach, there is no need to use the When and Do methods
            // But, the When and Do apporach is useful triggering other events
            // when something occurs in the test

            // arrange
            IFoo foo = Substitute.For<IFoo>();

            // act
            foo.SayHello("World");
            //foo.SayHello("World");

            // assert
            foo.Received(2).SayHello("World");
            // Using Received only works on virtual methods, non-virtual methods always returna true
            // this leads to false positive results, for safety use the When... Do... approach
        }
    }
}