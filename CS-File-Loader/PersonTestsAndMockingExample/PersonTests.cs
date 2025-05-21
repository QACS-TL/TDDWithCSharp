using NUnit.Framework;
using System.Collections.Generic;
using SimpleApplicationWithTest;
using NSubstitute;

namespace PersonTestsAndMockingExample
{
    public class PersonTests
    {
        public class MyList<T> : List<T>
        {
            public virtual long getSize()
            {
                return this.Count;
            }
        }

        [SetUp]
        public void Setup()
        {
        }
    
        [Test]
        public void person_objects_have_same_attributes_expect_true()
        {
            // Arrange
            Person p1 = new Person(52, "Selvyn", "Wright");
            Person p2 = new Person(52, "Selvyn", "Wright");
            bool expResult = true;

            // Act
            bool result = (p1 == p2);

            // Assert
            Assert.AreEqual(expResult, result);
        }


        [Test]
        public void Mocks_at_work()
        {
            // arrange
            var salmons = Substitute.For<MyList<string>>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");
            salmons.getSize().Returns(4);
            int expectedLength = 4;

            // act
            long result = salmons.getSize();

            // assert
            Assert.AreEqual(result, expectedLength);
        }
    }
}
