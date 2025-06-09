using Xunit;
using NodaTime;
using System.Globalization;
using System;
using Why_Spy_V2;
using NSubstitute;


namespace Why_Spy_Tests_V2
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
            //Assert.Fail("We have no real way of testing this code");
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

    }
}