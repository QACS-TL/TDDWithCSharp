using File_Loader_Service_V3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Tests_V3
{
    public class FileLoaderTestsV3
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
        public void LoadAllOfFileUsingDelegateWithStubbedData()
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
    }
}
