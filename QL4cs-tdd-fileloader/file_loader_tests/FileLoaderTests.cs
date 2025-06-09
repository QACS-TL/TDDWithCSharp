using Xunit;
using file_loader_service;
using System.Collections.Generic;
using System.IO;
using NSubstitute;

namespace file_loader_tests
{
    public class FileLoaderTests
    {
        [Fact]
        public void LoadAllOfFileUsingInbuiltFilesType()
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
        public void LoadAllOfFileUsingInbuiltFilesTypeAsLambda()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 10;
            List<string> pretendFileContent = new();
            pretendFileContent.Add("Hello");
            pretendFileContent.Add("world");

            var file = Substitute.For<MyFile>();
            file.ReadLines(fileToLoad).Returns(pretendFileContent);

            // act
            int bytesRead = cut.LoadFile(fileToLoad, (fname) =>
            {
                IEnumerable<string> result = file.ReadLines(fileToLoad);

                return result;
            });

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }

        [Fact]
        public void LoadAllOfFileUsingInbuiltFilesTypeViaLambda()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 638;

            // act
            int bytesRead = cut.LoadFile(fileToLoad, (fname) =>
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
        public void LoadAllOFileUsingDelegateWithStubbedData()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 55;

            // act
            int bytesRead = cut.LoadFile(fileToLoad, (fname) =>
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
        public void LoadAllOfFileUsingDelegateWithMock()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            List<string> pretendFileContent = new();
            pretendFileContent.Add("Hello");
            pretendFileContent.Add("world");
            int expectedBytesRead = 10;
            var file = Substitute.For<MyFile>();
            file.ReadLines(fileToLoad).Returns(pretendFileContent);

            // act
            int bytesRead = cut.LoadFile(fileToLoad, (fname) =>
            {
                IEnumerable<string> result = file.ReadLines(fileToLoad);

                return result;
            });

            // assert
            Assert.Equal(expectedBytesRead, bytesRead);
        }
    }
}