using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Service_V1
{
    public class FileLoader
    {

            private string fileData;
            IEnumerable<string> lines = new List<string>();
            public FileLoader()
            {
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
