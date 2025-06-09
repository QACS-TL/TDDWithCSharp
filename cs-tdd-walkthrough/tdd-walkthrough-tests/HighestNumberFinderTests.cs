using Xunit;
using tdd_workshop;

namespace tdd_walkthrough_tests
{
    public class HighestNumberFinderTests
    {
        [Fact]
        public void Find_highest_in_array_of_one()
        {
            // Arrange
            int expectedResult = 10;
            int[] numbers =
                {
                    expectedResult
                };
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighest(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Find_highest_in_array_of_two_descending_order()
        {
            // Arrange
            int expectedResult = 13;
            int[] numbers =
                {
                    expectedResult, 4
                };
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighest(numbers);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}