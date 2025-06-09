using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicManagerService
{
    public class TopicScoreWriter
    {
        private IFileWriter fileWriter;

        public TopicScoreWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void WriteScores(TopicTopScore[] topTopScores)
        {
            foreach (TopicTopScore tts in topTopScores)
            {
                string dataToWrite = tts.TopicName + ", " + tts.TopScore;
                fileWriter.WriteLine(dataToWrite);
            }
        }
    }
}
