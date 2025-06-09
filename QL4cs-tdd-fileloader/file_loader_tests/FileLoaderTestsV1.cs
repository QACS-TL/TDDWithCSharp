using File_Loader_Service_V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Tests_V1
{
    public class FileLoaderTestsV1
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
    }
}
