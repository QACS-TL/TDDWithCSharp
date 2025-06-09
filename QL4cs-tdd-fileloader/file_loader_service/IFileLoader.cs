using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Loader_Service_NFU
{
    public interface IFileLoader
    {
        public void LoadFile(string fname);

        public int CharCount();
    }
}
