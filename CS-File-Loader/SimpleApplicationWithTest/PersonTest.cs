using System;
using System.Linq;
using Xunit;

namespace SimpleApplicationWithTest
{
    public class PersonTest
    {
        [Fact]
        public void if_objects_are_fully_equal()
        {
            // Arrange
            Person p1 = new Person(52, "Selvyn", "Wright");
            Person p2 = new Person(52, "Selvyn", "Wright");
            bool expResult = true;

            // Act
            bool result = (p1 == p2);

            // Assert
            Assert.Equal(expResult, result);
        }

        [Fact]
        public void test_if_objects_are_fully_equal_vary_case()
        {
            // Arrange
            Person p1 = new Person(52, "Selvyn", "Wright");
            Person p2 = new Person(52, "selvyn", "Wright");
            bool expResult = true;

            bool result = (p1 == p2);

            Assert.Equal(expResult, result);
        }

        [Fact]
        public void test_if_objects_are_not_fully_equal()
        {
            // Arrange
            Person p1 = new Person(52, "Selvyn", "Wright");
            Person p2 = new Person(53, "Selvyn", "Wright");
            bool expResult = true;

            bool result = (p1 != p2);

            Assert.Equal(expResult, result);
        }
    }
}
