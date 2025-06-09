using FindHighestNumberService.v1;
using Xunit;

namespace FindHighestNumberTests.v1
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
    }
}