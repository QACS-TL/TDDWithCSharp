using NUnit.Framework;
using file_loader_service;
using System.Collections.Generic;
using System.IO;
using NSubstitute;

namespace file_loader_tests
{
    public class FileLoaderTests
    {
        [Test]
        public void load_all_of_file_using_inbuilt_Files_type()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.java.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 1383;

            // act
            int bytesRead = cut.LoadFile(fileToLoad);

            // assert
            Assert.AreEqual(expectedBytesRead, bytesRead);
        }

        [Test]
        public void load_all_of_file_using_inbuilt_Files_type_via_lambda()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.java.txt";
            FileLoader cut = new FileLoader();
            int expectedBytesRead = 1383;

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
            Assert.AreEqual(expectedBytesRead, bytesRead);
        }

        [Test]
        public void load_all_of_file_using_delegate_with_stubbed_data()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.java.txt";
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
            Assert.AreEqual(expectedBytesRead, bytesRead);
        }

        [Test]
        public void load_all_of_file_using_delegate_with_mock()
        {
            // arrange
            string fileToLoad = "c:/tmp/KeyboardHandler.java.txt";
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
            Assert.AreEqual(expectedBytesRead, bytesRead);
        }
    }
}