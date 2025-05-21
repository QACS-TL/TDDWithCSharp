using NUnit.Framework;
using System.Collections.Generic;
using LotteryService;

namespace tdd_cs_lotterytickets
{
    public class LotteryTicketHandlerTests
    {
        INumberGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new MyRandomNumberGenerator();
        }

        [Test]
        public void lottery_ticket_numbers_generated()
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
            Assert.AreEqual(expectedNumbers, result);
        }

        [Test]
        public void lottery_ticket_numbers_format_correctly()
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
            Assert.AreEqual(expResult, result);
        }
    }
}