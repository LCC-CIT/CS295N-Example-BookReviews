using BookReviews;
using Xunit;

namespace BookReviewTests
{
    public class QuizTests
    {
        // For use by all tests:
        const string WRONG_ANSWER = "wrong answer";
        const string RIGHT_ANSWER1 = "Victor Hugo";
        const string RIGHT_ANSWER2 = "1812";
        const string RIGHT_ANSWER3 = "false";

        [Fact]
        public void CheckAnswerWrongTest()
        {
            // arrange: done at class scope

            // act
           string result1 = Quiz.CheckAnswer(1, WRONG_ANSWER);
           string result2 = Quiz.CheckAnswer(2, WRONG_ANSWER);
           string result3 = Quiz.CheckAnswer(3, WRONG_ANSWER);

            // assert
            Assert.True(result1.Equals(Quiz.WRONG));
            Assert.True(result2.Equals(Quiz.WRONG));
            Assert.True(result3.Equals(Quiz.WRONG));
        }

        [Fact]
        public void CheckAnswerRightTest()
        {
            // arrange: done at class scope

            // act
            string result1 = Quiz.CheckAnswer(1, RIGHT_ANSWER1);
            string result2 = Quiz.CheckAnswer(2, RIGHT_ANSWER2);
            string result3 = Quiz.CheckAnswer(3, RIGHT_ANSWER3);

            // assert
            Assert.True(result1.Equals(Quiz.RIGHT));
            Assert.True(result2.Equals(Quiz.RIGHT));
            Assert.True(result3.Equals(Quiz.RIGHT));
        }

        [Fact]
        public void CheckAnswerNotAQuestionTest()
        {
            // arrange: done at class scope

            // act
            string result1 = Quiz.CheckAnswer(0, RIGHT_ANSWER1);
            string result2 = Quiz.CheckAnswer(4, RIGHT_ANSWER2);

            // assert
            Assert.True(result1.Equals(Quiz.NAQ));
            Assert.True(result2.Equals(Quiz.NAQ));
        }
    }
}
