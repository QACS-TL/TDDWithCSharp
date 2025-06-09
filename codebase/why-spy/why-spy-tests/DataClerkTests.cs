using NUnit.Framework;
using System;
using why_spy;
using NSubstitute;

namespace why_spy_tests
{
    public class DataClerkTests
    {
        [Test]
        public void Files_are_logged_before_8pm()
        {
            // arrange
            FileLog fl = new FileLog();
            DataClerk cut = new DataClerk(fl);

            // act
            cut.ProcessData();

            // assert
            // We have no of verifying what's happened in the CUT
        }

        [Test]
        public void Files_are_logged_before_8pm_mocked()
        {
            // arrange
            IFileLog fl = Substitute.For<IFileLog>();
            var count = 0;
            fl.When(x => x.ClearTheLog())
                .Do(callInfo =>
                {
                    count++;
                    Console.WriteLine("executing the lambda");
                });
            DataClerk cut = new DataClerk(fl);

            // act
            cut.ProcessData();

            // assert
            Assert.AreEqual(1, count);
        }

        [Test]
        public void Files_are_wrongly_logged_after_8pm_mocked_()
        {
            // arrange
            IFileLog fl = Substitute.For<IFileLog>();
            var count = 0;
            int exptectedResult = 0;
            fl.When(x => x.ClearTheLog())
                .Do(callInfo =>
                {
                    count++;
                    Console.WriteLine("executing the lambda");
                });
            DataClerk cut = new DataClerk(fl);

            // act
            cut.ProcessData();

            // assert
            Assert.AreEqual(exptectedResult, count);
            // It falils if run before 8pm, not what I wanted
        }

        [Test]
        public void Files_are_logged_after_8pm_using_spy()
        {
            // arrange
            IFileLog fl = Substitute.For<IFileLog>();
            var count = 0;
            int expectedCount = 1;
            fl.When(x => x.ClearTheLog())
                .Do(callInfo =>
                {
                    count++;
                    Console.WriteLine("executing the lambda");
                });
            DataClerk cut = Substitute.ForPartsOf<DataClerk>();
            cut.SetFileLog(fl);
            cut.CurrentDateTime().Returns(x =>
            {
                DateTime now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day, 14, 46, 0, 0);
            });

            // act
            cut.ProcessData();

            // assert
            Assert.AreEqual(expectedCount, count);
        }
    }
}