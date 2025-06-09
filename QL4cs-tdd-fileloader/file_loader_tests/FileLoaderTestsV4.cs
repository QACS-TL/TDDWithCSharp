using File_Loader_Service_V4;
using File_Loader_Tests;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Tests_V4
{
    public class FileLoaderTestsV4
    {
        [Fact]
        public void LoadAllOfFileUsingInbuiltFileType()
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
        public void LoadAllOfFileUsingInbuiltFileTypeViaLambda()
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
        public void LoadAllOfFileUsingDelegateWithWithMock()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.cs.txt";
            FileLoader cut = new FileLoader();
            List<string> pretendFileContent = new();
            // setup ur canned data, these will represent the lines in the file
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
