using Tokeniser;

namespace StringTokeniserTests
{
    public class StringTokeniserTests
    {
        [Fact]
        public void EmptyStringResultEmptyArray()
        {
            // If this was the only requirement, then the CUT as coded would be sufficient
            // arrange
            String inputVal = "";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void StringOfOneResultArrayOfOne()
        {
            // arrange
            String inputVal = "csharp";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "csharp" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void StringOfTwoItemsResultArrayOfTwoStrings()
        {
            // arrange
            String inputVal = "csharp,python";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "csharp", "python" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void StringOfManyItemsNoSpacesResultArrayOfManyStrings()
        {
            // With this test the CUT still works
            // arrange
            String inputVal = "java,C#,python";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "java", "C#", "python" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }



        [Fact]
        public void StringOfCompoundItemsNoSpacesResultArrayOfManyStrings()
        {
            // With this test the CUT still works
            // arrange
            String inputVal = "C# byte code,java,python";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "C# byte code", "java", "python" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void StringOfOneResultArrayOfOneSpacesRemoved()
        {
            // Initially this test will fail, the CUT needs a trim() method to be called
            // arrange
            String inputVal = " csharp ";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "csharp" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void StringOfOneWithPrecedingCommaResultArrayOfOneSpacesRemoved()
        {
            // CUT still works as required
            // arrange
            String inputVal = ",csharp";
            StringTokeniser cut = new StringTokeniser();
            String[] expectedResult = { "csharp" };

            // act
            String[] actualResult = cut.tokenise(inputVal);

            // assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
