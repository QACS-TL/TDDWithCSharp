using FindHighestNumberService.v2;
using Xunit;

namespace HighestNumberFinderTests.v2
{
    public class FindHighestNumberTests
    {
        [Fact]
        public void Array_of_one_item_returns_this_item()
        {
            // Arrange
            int[] values = { 33 };
            int expectedResult = 33;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Array_of_two_descending_items_return_first_item()
        {
            // Arrange
            int[] values = { 13, 4 };
            int expectedResult = 13;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
