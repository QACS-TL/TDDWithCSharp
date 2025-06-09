using Xunit;
using NSubstitute;
using System.Collections.Generic;
using System.IO;
// This is an enterprise feature
//using Microsoft.QualityTools.Testing.Fakes;

using SimpleApplicationWithTest;

namespace NUnit_FileLoader
{
    public class FileLoaderTest
    {
		[Fact]
        public void load_all_of_file_using_direct_load()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 638;

            // act
            int bytesRead = cut.LoadFile(fileToLoad);

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }

        [Fact]
        public void load_all_of_file_using_delegate()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader(fileToLoad);
            int expectedBytesRead = 638;

            // act
            int bytesRead = cut.LoadFile((fname)=>
            {
                IEnumerable<string> result = null;
                try
                {
                    result = File.ReadLines(fname);
                }
                catch (IOException e) { }
                return result;
            });

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }

		[Fact]
        public void load_all_of_file_using_delegate_with_stubbed_data()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader(fileToLoad);
            int expectedBytesRead = 55;

            // act
            int bytesRead = cut.LoadFile((fname) =>
            {
                List<string> result = new();

                result.Add("using NUnit.Framework;");
                result.Add("using System.Collections.Generic;");

                return result;
            });

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }

		[Fact]
        public void load_all_of_file_using_delegate_with_mock()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader(fileToLoad);
            List<string> pretendFileContent = new();
            pretendFileContent.Add("Hello");
            pretendFileContent.Add("world");
            int expectedBytesRead = 10;
            var file = Substitute.For<MyFileImpl>();
            file.ReadLines(fileToLoad).Returns(pretendFileContent);

            // act
            int bytesRead = cut.LoadFile((fname) =>
            {
                IEnumerable<string> result = file.ReadLines(fileToLoad);

                return result;
            });

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }

        // This is an enterprise feature, not available in standard VS
        /*
		[Fact]
        public void check_the_file_length_Shim()
        {
            // Arrange
            int expected = 5;
            FileLoader cut = new();
            int actual;
            // Act
            using (ShimsContext.Create())
            {
                ShimFile.ReadAllTextString = (filename) => new string("Hello");
                actual = cut.LoadFile(testFile);
            }
            // Assert
            Assert.Equal(expected, actual);
        }
        */
    }
}