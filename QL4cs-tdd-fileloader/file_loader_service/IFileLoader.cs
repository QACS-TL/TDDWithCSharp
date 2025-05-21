using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_loader_service_nfu
{
    public interface IFileLoader
    {
        public void LoadFile(string fname);

        public int CharCount();
    }
}
