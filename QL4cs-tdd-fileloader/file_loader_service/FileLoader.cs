using System;
using System.Collections.Generic;
using System.IO;

namespace file_loader_service
{
    public delegate IEnumerable<string> ILoadFile(String fname);

    public class FileLoader
    {
        IEnumerable<string> lines = new List<string>();

        public FileLoader()
        {
        }

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
            };

            return result;
        }
    }
}
