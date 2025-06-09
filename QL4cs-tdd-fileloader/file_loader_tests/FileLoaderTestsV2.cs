using File_Loader_Service_V2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Tests_V2
{
    public class FileLoaderTestsV2
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
    }
}
