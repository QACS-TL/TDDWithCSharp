using Xunit;
using NodaTime;
using System.Globalization;
using System;
using Why_Spy_V4;
using NSubstitute;


namespace Why_Spy_Tests_V4
{

    public class DataClerkTests
    {
        [Fact]
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

        [Fact]
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
            Assert.Equal(1, count);
        }

        [Fact]
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
            Assert.Equal(exptectedResult, count);
            // It fails if run before 8pm, not what I wanted
        }
    }
}