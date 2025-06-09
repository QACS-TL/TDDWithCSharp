using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TopicManagerService
{
    public class TopicScores // TopicScores.cs
    {
        public TopicScores(string topicName, int []scores)
        {
            TopicName = topicName;
            Scores = scores;
        }

        public string TopicName { get; set; }
        public int[] Scores { get; set; }
    }
}
