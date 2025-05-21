using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace file_loader_tests
{
    public  interface MyFile
    {
        public abstract IEnumerable<string> ReadLines(string path);
    }
}
