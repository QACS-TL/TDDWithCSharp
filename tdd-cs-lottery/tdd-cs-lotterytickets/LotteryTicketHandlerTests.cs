using Xunit;
using System.Collections.Generic;
using NSubstitute;
using LotteryService;

namespace tdd_cs_lotterytickets
{
    public class LotteryTicketHandlerTests
    {
        INumberGenerator generator;


        public LotteryTicketHandlerTests()
        {
            generator = new MyRandomNumberGenerator();
        }

        [Fact]
        public void LotteryTicketNumbersGenerated()
        {
            // arrange
            LotteryHandler cut = new LotteryHandler(generator);
            HashSet<int> expectedNumbers = new ();
            expectedNumbers.Add(1);
            expectedNumbers.Add(2);
            expectedNumbers.Add(3);
            expectedNumbers.Add(4);
            expectedNumbers.Add(5);

            // act
            HashSet<int> result = cut.GenerateRandomSet();

            // assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void LotteryTicketNumbersGeneratedUsingMock()
        {
            // arrange
            var generator = Substitute.For<INumberGenerator>();

            generator.generate(99).Returns( 0, 1, 2, 3, 4); // Mocking the generator to return specific values

            LotteryHandler cut = new LotteryHandler(generator);
            HashSet<int> expectedNumbers = new();
            expectedNumbers.Add(1);
            expectedNumbers.Add(2);
            expectedNumbers.Add(3);
            expectedNumbers.Add(4);
            expectedNumbers.Add(5);

            // act
            HashSet<int> result = cut.GenerateRandomSet();

            // assert
            Assert.Equal(expectedNumbers, result);
        }

        [Fact]
        public void LotteryTicketNumbersFormatCorrectly()
        {
            // arrange
            LotteryHandler cut = new LotteryHandler(generator);
            HashSet<int> expectedNumbers = new();
            expectedNumbers.Add(1);
            expectedNumbers.Add(2);
            expectedNumbers.Add(3);
            expectedNumbers.Add(4);
            expectedNumbers.Add(5);
            string expResult = "1 - 2 - 3 - 4 - 5";

            // act
            string result = cut.format(expectedNumbers);

            // assert
            Assert.Equal(expResult, result);
        }
    }
}