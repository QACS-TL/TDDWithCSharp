using NSubstitute;
using QLC1HighestNumberFinderService;
using TopicManagerService;

namespace TopicManagerTests
{
    public class TopicManagerTests
    {
        [Fact]
        public void FindHighestScoreInEmptyArrayReturnEmptyArray()
        {
            // Arrange
            TopicScores[] array = Array.Empty<TopicScores>();
            //TopicManager cut = new TopicManager();
            TopicManager cut = new TopicManager(new HighestNumberFinder());
            TopicTopScore[] expectedResult = Array.Empty<TopicTopScore>();

            // Act
            TopicTopScore[] result = cut.FindTopicHighScores(array);

            // Assert
            Assert.Equal(result, result);
        }

        [Fact]
        public void FindHighestScoreWithArrayOfOneReturnArrayOfOne()
        {
            // Arrange
            int[] scores = { 56, 67, 45, 89 };
            string topicName = "Physics";
            TopicScores[] topicScores = { new TopicScores(topicName, scores) };
            //TopicManager cut = new TopicManager();
            TopicManager cut = new TopicManager(new HighestNumberFinder());
            TopicTopScore[] expectedResult = { new TopicTopScore(topicName, 89) };
            // Act
            TopicTopScore[] result = cut.FindTopicHighScores(topicScores);
            // Assert
            Assert.Equal(expectedResult[0].TopicName, result[0].TopicName);
            Assert.Equal(expectedResult[0].TopScore, result[0].TopScore);
        }

        [Fact]
        public void FindHighestScoreWithArrayOfOneReturnArrayOfOneUsingStub()
        {
            // Arrange
            int[] scores = { 56, 67, 45, 89 };
            string topicName = "Physics";
            TopicScores[] topicScores = { new TopicScores(topicName, scores) };
            IHighestNumberFinder hnf = new TopicManagerServiceStubs.HighestNumberFinder();
            TopicManager cut = new TopicManager(hnf);
            TopicTopScore[] expectedResult = { new TopicTopScore(topicName, 89) };

            // Act
            TopicTopScore[] result = cut.FindTopicHighScores(topicScores);

            // Assert
            Assert.Equal(expectedResult[0].TopicName, result[0].TopicName);
            Assert.Equal(expectedResult[0].TopScore, result[0].TopScore);
        }


        [Fact]
        public void FindHighestScoreWithArrayOfManyReturnArrayOfManyUsingStub()
        {
            //[{“Physics”, { 56, 67, 45, 89} }, {“Art”, { 87, 66, 78} }, {“Comp Sci”, { 45, 88, 97, 56} }]
            // Arrange
            int[] physics_scores = { 56, 67, 45, 89 };
            string physics = "Physics";
            int[] art_scores = { 87, 66, 78 };
            string art = "Art";
            TopicScores[] topicScores = { new TopicScores(physics, physics_scores),
                                          new TopicScores(art, art_scores)};
            IHighestNumberFinder hnf = new TopicManagerServiceStubs.HighestNumberFinder();
            TopicManager cut = new TopicManager(hnf);
            TopicTopScore[] expectedResult = {  new TopicTopScore("Physics", 89),
                                                new TopicTopScore("Art", 87) };

            // Act
            TopicTopScore[] result = cut.FindTopicHighScores(topicScores);

            // Assert
            Assert.Equal(expectedResult[0].TopicName, result[0].TopicName);
            Assert.Equal(expectedResult[0].TopScore, result[0].TopScore);
            Assert.Equal(expectedResult[1].TopicName, result[1].TopicName);
            Assert.Equal(expectedResult[1].TopScore, result[1].TopScore);
        }

        [Fact]
        public void FindHighestScoreWithArrayOfManyReturnArrayOfManyUsingMock()
        {
            //[{“Physics”, { 56, 67, 45, 89} }, {“Art”, { 87, 66, 78} }, {“Comp Sci”, { 45, 88, 97, 56} }]
            // Arrange
            int[] physics_scores = { 56, 67, 45, 89 };
            string physics = "Physics";
            int[] art_scores = { 87, 66, 78 };
            string art = "Art";
            int[] compSci_scores = { 45, 88, 97, 56 };
            string compSci = "Comp Sci";
            TopicScores[] topicScores = { new TopicScores(physics, physics_scores),
                                          new TopicScores(art, art_scores),
                                          new TopicScores(compSci, compSci_scores)};

            // Setup your expectations
            IHighestNumberFinder hnf = Substitute.For<IHighestNumberFinder>();
            hnf.FindHighestNumber(physics_scores).Returns(89);
            hnf.FindHighestNumber(art_scores).Returns(87);
            hnf.FindHighestNumber(compSci_scores).Returns(97);

            TopicManager cut = new TopicManager(hnf);

            TopicTopScore[] expectedResult = {  new TopicTopScore("Physics", 89),
                                                new TopicTopScore("Art", 87),
                                                new TopicTopScore("Comp Sci", 97) };

            // Act
            TopicTopScore[] result = cut.FindTopicHighScores(topicScores);

            // Assert
            Assert.Equal(expectedResult[0].TopicName, result[0].TopicName);
            Assert.Equal(expectedResult[0].TopScore, result[0].TopScore);
            Assert.Equal(expectedResult[1].TopicName, result[1].TopicName);
            Assert.Equal(expectedResult[1].TopScore, result[1].TopScore);
            Assert.Equal(expectedResult[2].TopicName, result[2].TopicName);
            Assert.Equal(expectedResult[2].TopScore, result[2].TopScore);
        }
    }
}