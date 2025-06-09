using System;
using NodaTime;

namespace Why_Spy_V1
{
    public class DataClerk
    {
        private FileLog theFileLog;

        public DataClerk(FileLog fl)
        {
            theFileLog = fl;
        }

        public void ProcessData()
        {
            DateTime now = DateTime.Now;
            DateTime stopTime = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0, 0);

            if (now < stopTime)
            {
                Console.WriteLine("Ready to process the data");
                theFileLog.ClearTheLog();
            }
        }
    }

    public class FileLog
    {
        public void ClearTheLog()
        {
            // Simulated method that would do something to files in the log
        }
    }
}
