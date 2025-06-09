using Xunit;
using NodaTime;
using System.Globalization;
using System;
using Why_Spy_V1;
using NSubstitute;

namespace Why_Spy_Tests_V1
{

    public class DataClerkTests
    {
        [Fact]
        public void FilesAreLoggedBefore8pm()
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



    }
}