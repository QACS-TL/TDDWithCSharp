using FindHighestNumberService;
using NUnit.Framework;

namespace TopicManagerService
{
    public class TopicManagerTests
    {
        [Test]
        public void find_heighest_score_in_empty_array_return_empty_array()
        {
            // Arrange
            TopicScores[] topicScores = Array.Empty<TopicScores>();
            IHighestNumberFinder hnf = new FindHighestNumberServiceFinal.HighestNumberFinder();
            TopicManager cut = new TopicManager(hnf);
            TopicTopScore[] expectedResult = Array.Empty<TopicTopScore>();

            // Act
            TopicTopScore[] result = cut.findTopicHighScores(topicScores);

            // Assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void find_heighest_score_with_array_of_one_return_array_of_one()
        {
            // Arrange
            int[] scores = { 56, 67, 45, 89 };
            string topicName = "Physics";
            TopicScores[] topicScores = { new TopicScores(topicName, scores) };
            IHighestNumberFinder hnf = new FindHighestNumberServiceFinal.HighestNumberFinder();
            TopicManager cut = new TopicManager(hnf);
            TopicTopScore[] expectedResult = {new TopicTopScore(topicName, 89)};

            // Act
            TopicTopScore[] result = cut.findTopicHighScores(topicScores);

            // Assert
            Assert.AreEqual(result[0].TopicName, expectedResult[0].TopicName);
            Assert.AreEqual(result[0].TopScore, expectedResult[0].TopScore);
        }

        [Test]
        public void find_heighest_score_with_array_of_one_return_array_of_one_using_stub()
        {
            // Arrange
            int[] scores = { 56, 67, 45, 89 };
            string topicName = "Physics";
            TopicScores[] topicScores = { new TopicScores(topicName, scores) };
            IHighestNumberFinder hnf = new TopicManagerService.HighestNumberFinder();
            TopicManager cut = new TopicManager(hnf);
            TopicTopScore[] expectedResult = { new TopicTopScore(topicName, 89) };

            // Act
            TopicTopScore[] result = cut.findTopicHighScores(topicScores);

            // Assert
            Assert.AreEqual(result[0].TopicName, expectedResult[0].TopicName);
            Assert.AreEqual(result[0].TopScore, expectedResult[0].TopScore);
        }
    }
}