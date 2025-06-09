using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NUnit_FileLoader
{
    public  class MyFileImpl
    {
        public virtual IEnumerable<string> ReadLines(string path)
        {
            return File.ReadLines(path);
        }
    }
}
