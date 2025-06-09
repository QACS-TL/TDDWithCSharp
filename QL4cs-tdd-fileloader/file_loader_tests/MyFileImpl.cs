using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File_Loader_Tests
{
    public  interface MyFile
    {
        public abstract IEnumerable<string> ReadLines(string path);
    }
}
