using System;
using NodaTime;

namespace Why_Spy_VE
{
    public interface IFileLog
    {
        public void ClearTheLog();
    }

    public class DataClerk
    {
        private IFileLog theFileLog;

        public DataClerk( IFileLog fl )
        {
            theFileLog = fl;
        }

        public  DataClerk()
        { }

        public  void    SetFileLog( IFileLog fl )
        {
            theFileLog = fl;
        }

        virtual public DateTime CurrentDateTime()
        {
            return DateTime.Now;
        }

        public  void    ProcessData()
        {
            DateTime now = CurrentDateTime();
            DateTime stopTime = new DateTime(now.Year, now.Month, now.Day, 20, 0, 0, 0);

            if( now < stopTime )
            {
                Console.WriteLine("Ready to process the data");
                theFileLog.ClearTheLog();
            }
        }
    }

    public class FileLog : IFileLog
    {
        virtual public  void    ClearTheLog()
        {
            // Simulated method that would do something to files in the log
        }
    }
}
