using PersonUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonUtils.Tests
{
    public class PersonTests
    {
        [Fact]
        public void Two_Identical_Objects_Result_True()
        {
            // Arrange
            Person p1 = new Person(32, "Selvyn", "Wright");
            Person p2 = new Person(32, "Selvyn", "Wright");
            bool expectedResult = true;

            // Act
            bool result = p1 == p2;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Two_Identical_Object_References_Result_True()
        {
            // Arrange
            Person p1 = new Person(32, "Selvyn", "Wright");
            Person p2 = p1;
            bool expectedResult = true;

            // Act
            bool result = p1 == p2;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LH_null_RH_Concrete_Result_False()
        {
            // Arrange
            Person lh = null;
            Person rh = new Person(32, "Selvyn", "Wright");
            bool expectedResult = false;

            // Act
            bool result = lh == rh;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LH_Concrete_RH_null_Result_False()
        {
            // Arrange
            Person lh = new Person(32, "Selvyn", "Wright");
            Person rh = null;
            bool expectedResult = false;

            // Act
            bool result = lh == rh;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LH_Lower_Than_RH_Result_False()
        {
            // Arrange
            Person lh = new Person(32, "selvyn", "Wright");
            Person rh = new Person(32, "Selvyn", "Wright");
            bool expectedResult = false;

            // Act
            bool result = lh == rh;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LH_Less_Than_RH_Result_False()
        {
            // Arrange
            Person lh = new Person(32, "Selvym", "Wright");
            Person rh = new Person(32, "Selvyn", "Wright");
            bool expectedResult = true;

            // Act
            bool result = lh < rh;

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void LH_Greater_Than_RH_Result_False()
        {
            // Arrange
            Person lh = new Person(32, "Selvyo", "Wright");
            Person rh = new Person(32, "Selvyn", "Wright");
            bool expectedResult = true;

            // Act
            bool result = lh > rh;

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}