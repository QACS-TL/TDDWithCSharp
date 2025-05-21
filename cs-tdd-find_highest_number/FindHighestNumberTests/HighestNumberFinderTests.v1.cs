using FindHighestNumberService.v1;
using NUnit.Framework;

namespace FindHighestNumberTests.v1
{
    public class FindHighestNumberTests
    {
        [Test]
        public void Array_of_one_item_returns_this_item()
        {
            // Arrange
            int[] values = { 33 };
            int expectedResult = 33;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}