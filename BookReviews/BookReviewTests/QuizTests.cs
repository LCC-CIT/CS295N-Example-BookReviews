using BookReviews;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookReviewTests
{
    public class QuizTests
    {
        [Fact]
        public void CheckAnswerWrongTest()
        {
            // arrange
            string answer1 = "something";
            string answer2 = "something";
            string answer3 = "something";

            // act
           string result1 = Quiz.CheckAnswer(1, answer1);
           string result2 = Quiz.CheckAnswer(2, answer2);
           string result3 = Quiz.CheckAnswer(3, answer3);

            // assert
            Assert.True(result1.Equals(Quiz.WRONG));
            Assert.True(result2.Equals(Quiz.WRONG));
            Assert.True(result3.Equals(Quiz.WRONG));
        }

        [Fact]
        public void CheckAnswerRightTest()
        {
            // arrange
            string answer1 = "Victor Hugo";
            string answer2 = "1812";
            string answer3 = "false";

            // act
            string result1 = Quiz.CheckAnswer(1, answer1);
            string result2 = Quiz.CheckAnswer(2, answer2);
            string result3 = Quiz.CheckAnswer(3, answer3);

            // assert
            Assert.True(result1.Equals(Quiz.RIGHT));
            Assert.True(result2.Equals(Quiz.RIGHT));
            Assert.True(result3.Equals(Quiz.RIGHT));
        }
    }
}
