using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Service_V2
{
    public delegate IEnumerable<string> ILoadFile(String fname);

    public class FileLoader
    {

        IEnumerable<string> lines = new List<string>();

        public int LoadFile(string fname, ILoadFile func)
        {
            lines = func(fname);
            return CalculateFileSize();
        }

        public int LoadFile(string fname)
        {
            try
            {
                lines = File.ReadLines(fname);
            }
            catch (IOException e) { }
            return CalculateFileSize();
        }

        private int CalculateFileSize()
        {
            int result = 0;
            foreach (string line in lines)
            {
                result += line.Length;
            }
            ;
            return result;
        }
    }
}
