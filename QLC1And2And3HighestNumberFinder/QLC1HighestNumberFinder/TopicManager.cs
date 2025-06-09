using QLC1HighestNumberFinderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicManagerService
{
    public class TopicManager
    {
        private IHighestNumberFinder highestNumberFinder;

        public TopicManager(IHighestNumberFinder hnf)
        {
            highestNumberFinder = hnf;
        }

        public TopicTopScore[] FindTopicHighScores(TopicScores[] array)
        {
            if (array.Length >= 1)
            {
                List<TopicTopScore> topScores = new List<TopicTopScore>();
                foreach(TopicScores ts in array)
                {
                    int topScore = highestNumberFinder.FindHighestNumber(ts.Scores);
                    topScores.Add(new TopicTopScore(ts.TopicName, topScore));
                }
                //TopicScores ts = array[0];
                //int topScore = highestNumberFinder.FindHighestNumber(ts.Scores);
                //topScores.Add(new TopicTopScore(ts.TopicName, topScore));
                return topScores.ToArray();
            }
            else
                return Array.Empty<TopicTopScore>();
        }
    }
}
