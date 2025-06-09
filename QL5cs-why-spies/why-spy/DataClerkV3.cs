using System;
using NodaTime;

namespace Why_Spy_V3
{
    public interface IFileLog
    {
        public void ClearTheLog();
    }

    public class DataClerk
    {
        private IFileLog theFileLog;

        public DataClerk(IFileLog fl)
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

    public class FileLog : IFileLog
    {
        public void ClearTheLog()
        {
            // Simulated method that would do something to files in the log
        }
    }
}
