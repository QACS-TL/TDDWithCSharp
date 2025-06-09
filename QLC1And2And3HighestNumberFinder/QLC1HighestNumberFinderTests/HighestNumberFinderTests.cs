using QLC1HighestNumberFinderService;

namespace QLC1HighestNumberFinderTests
{
    public class HighestNumberFinderTests
    {
        [Fact]
        public void ArrayOfOneItemReturnsThisItem()
        {
            // Arrange
            int[] values = { 13 };
            int expectedResult = 13;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.FindHighestNumber(values);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ArrayOfTwoAscendingItemsReturnFirstItem()
        {
            // Arrange
            int[] values = { 13, 4 };
            int expectedResult = 13;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.FindHighestNumber(values);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ArrayOfTwoAscendingItemsReturnLastItem()
        {
            // Arrange
            int[] array = { 7, 13 };
            int expectedResult = 13;
            HighestNumberFinder cut = new HighestNumberFinder();

            // Act
            int result = cut.FindHighestNumber(array);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void FindHighestInArrayOfOneExpectSingleItem()
        {
            // Arrange
            int[] array = { 10 };
            HighestNumberFinder cut = new HighestNumberFinder();
            int expectedResult = 10;

            // Act
            int result = cut.FindHighestNumber(array);

            // Assert
            Assert.Equal(expectedResult, result);
        }


    }
}