using NSubstitute;
using TopicManagerService;


namespace TopicScoreWriterTests
{
    public class TopicScoreWriterTest
    {
        [Fact]
        public void VerifyTopicScoreDetailsWrittenOutOnce()
        {
            // arrange
            String physics = "Physics";
            String expectedResult = "Physics, 89";
            TopicTopScore[] topTopScores = { new TopicTopScore(physics, 89) };
            IFileWriter fileWriter = Substitute.For<IFileWriter>();
            TopicScoreWriter cut = new TopicScoreWriter(fileWriter);
            // act
            cut.WriteScores(topTopScores);
            // assert
            fileWriter.Received(1).WriteLine(expectedResult);
        }

        [Fact]
        public void VerifyEmptyArrayTopicScoreNotWritten()
        {
            // arrange
            String physics = "Physics";
            String art = "Art";
            String compSci = "Comp Sci";
            String expectedResult = "Physics, 89";
            TopicTopScore[] topTopScores = Array.Empty<TopicTopScore>();
            IFileWriter fileWriter = Substitute.For<IFileWriter>();
            TopicScoreWriter cut = new TopicScoreWriter(fileWriter);

            // act
            cut.WriteScores(topTopScores);

            // assert
            fileWriter.DidNotReceive().WriteLine(expectedResult);
        }

        [Fact]
        public void VerifyTopicScoreDetailsWrittenOutMultipleTimes()
        {
            // arrange
            string physics = "Physics";
            string art = "Art";
            string compSci = "Comp Sci";
            string physicsResult = "Physics, 89";
            string artsResult = "Art, 87";
            string comSciResult = "Comp Sci, 97";

            TopicTopScore[] topTopScores = { new TopicTopScore(physics, 89),
                                             new TopicTopScore(art, 87),
                                             new TopicTopScore(compSci, 97)};

            String fileToWrite = "testfile.txt";
            IFileWriter fileWriter = Substitute.For<IFileWriter>();

            TopicScoreWriter cut = new TopicScoreWriter(fileWriter);

            // act
            cut.WriteScores(topTopScores);

            // assert
            fileWriter.Received(1).WriteLine(physicsResult);
            fileWriter.Received(1).WriteLine(artsResult);
            fileWriter.Received(1).WriteLine(comSciResult);
        }
    }
}