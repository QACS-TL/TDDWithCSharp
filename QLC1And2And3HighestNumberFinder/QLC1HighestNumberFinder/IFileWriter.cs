using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicManagerService
{
    public interface IFileWriter
    {
        void WriteLine(String lineToWrite);
    }
}

