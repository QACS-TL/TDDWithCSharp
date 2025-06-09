using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace SimpleApplicationWithTest
{
    public  delegate IEnumerable<string> ILoadFile(String fname);

    public class FileLoader
    {
        private string fileData;
        string fileToLoad;
        IEnumerable<string> lines = new List<string>();

        public int LoadFile(ILoadFile func)
        {
            lines = func(fileToLoad);
            return CalculateFileSize();
        }

        public FileLoader()
        { }

        public  FileLoader(string fname)
        {
            fileToLoad = fname;
        }

        public  int CharCount()
        {
            return fileData.Length;
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

            foreach( string line in lines) 
            { 
                result += line.Length;
            };

            return result;
        }
    }
}
