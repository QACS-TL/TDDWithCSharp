using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace TopicManagerService
{
    public class TopicTopScore // TopicTopScore.cs
    {
        public TopicTopScore(string topicName, int score)
        {
            TopicName = topicName;
            TopScore = score;
        }

        public string TopicName { get; set; }
        public int TopScore { get; set; }
    }
}
