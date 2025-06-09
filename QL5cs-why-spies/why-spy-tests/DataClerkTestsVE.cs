using Xunit;
using NodaTime;
using System.Globalization;
using System;
using Why_Spy_VE;
using NSubstitute;

namespace Why_Spy_Tests_VE
{
    public class StubClass
    {
        private IFileLog fl;

        public StubClass()
        {}

        public StubClass(IFileLog fl)
        {
            this.fl = fl;
        }

        public void processTheData(IFileLog pfl)
        {
            Console.WriteLine("StubClass::processTheData()");
            fl.ClearTheLog();
        }

        virtual public DateTime CurrentDateTime()
        { 
            return DateTime.Now; 
        }
    }
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
            Assert.Fail("We have no real way of testing this code");
        }

        [Fact]
        public void Files_are_logged_before_8pm_mocked()
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
            DataClerk cut = new DataClerk(fl);

            // act
            cut.ProcessData();

            // assert
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public void Files_are_logged_after_8pm()
        {
            // arrange
            IFileLog fl = Substitute.For<IFileLog>();
            var count = 0;
            int expectedCount = 0;
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
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public  void    Play_with_NSubstitute_features_spy_no_override()
        {
            // arrange
            var cut = Substitute.ForPartsOf<StubClass>();

            // act
            DateTime now = cut.CurrentDateTime();
            DateTime nowDelta = DateTime.Now;

            // assert
            Assert.Equal(now.Hour, nowDelta.Hour);
            Assert.Equal(now.Minute, nowDelta.Minute);
        }

        [Fact]
        public void Play_with_NSubstitute_features_spy_with_override()
        {
            // arrange
            var cut = Substitute.ForPartsOf<StubClass>();
            cut.CurrentDateTime().Returns(x =>
            {
                DateTime now = DateTime.Now;
                return new DateTime(now.Year, now.Month, now.Day, 14, 46, 0, 0);
            });

            // act
            DateTime now = cut.CurrentDateTime();
            DateTime nowDelta = DateTime.Now;

            // assert
            Assert.Equal(now.Hour, nowDelta.Hour);
            Assert.Equal(now.Minute, nowDelta.Minute);
        }

        [Fact]
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
            Assert.Equal(expectedCount, count);
        }

        [Fact]
        public void Files_are_logged_after_8pm_using_spy_alternative_syntax()
        {
            // arrange
            IFileLog fl = Substitute.For<IFileLog>();
            var count = 0;
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
            fl.Received(1).ClearTheLog();
        }

    }
}