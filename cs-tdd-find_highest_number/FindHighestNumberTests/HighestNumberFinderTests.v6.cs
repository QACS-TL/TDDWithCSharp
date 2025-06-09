using FindHighestNumberService.v6;
using Xunit;

namespace HighestNumberFinderTests.v6
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

        [Fact]
        public void Array_of_two_ascending_items_return_last_item()
        {
            // Arrange
            int[] values = { 7, 13 };
            int expectedResult = 13;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Array_of_two_equal_items_return_either_item()
        {
            // Arrange
            int[] values = { 7, 7 };
            int expectedResult = 7;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Array_several_items_return_highest_item()
        {
            // Arrange
            int[] values = { 4, 5, -8, 3, 11, -21, 6 };
            int expectedResult = 11;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.findHighestNumber(values);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void An_empty_array_throws_an_exception()
        {
            // Arrange
            int[] values = {};
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act + Assert
            Assert.Throws<EmptyArrayException>(() => cut.findHighestNumber(values));
        }
    }
}
