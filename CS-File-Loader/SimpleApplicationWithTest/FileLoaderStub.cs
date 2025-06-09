using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApplicationWithTest
{
    class FileLoaderStub
    {
        private string fileData;

        public void LoadFile(string fname)
        {
            fileData = "Some random data";
        }

        public int CharCount()
        {
            return fileData.Length;
        }
    }
}
