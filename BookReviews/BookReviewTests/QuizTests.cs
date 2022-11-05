﻿using BookReviews;
using System.Collections.Generic;
using Xunit;

namespace BookReviewTests
{
    public class QuizTests
    {
        [Fact]
        public void CheckAnswerRightTest()
        {
            // arrange: 
            var set = Quiz.GenerateQuestionSet();
            // set all the answers to the right answer
            foreach(var answer in set)
            {
                answer.UserAnswer = answer.Answer;
            }

            // act
            Quiz.CheckAnswers(set);

            // assert
            bool result = true;  // assume all the answers were right
            // change result if ANY answer is wrong
            foreach(var answer in set)
            {   
                result = result && (answer.IsRight ?? false);  // count null as false
            }
            Assert.True(result);
        }

        [Fact]
        public void CheckAnswerWrongTest()
        {
            // arrange: 
            var set = Quiz.GenerateQuestionSet();
            // set all the answers to the wrong answer
            foreach (var answer in set)
            {
                answer.UserAnswer = "Something random";
            }

            // act
            Quiz.CheckAnswers(set);

            // assert
            bool result = false;  // assume all the answers were wrong
            // change result if ANY answer is right
            foreach (var answer in set)
            {
                result = result || (answer.IsRight ?? false);  // count null as false
            }
            Assert.False(result);
        }

        [Fact]
        public void UniqueIdTest()
        {
            // arrange: not needed

            // act
            var set = Quiz.GenerateQuestionSet();

            // assert
            // Make a list of all the QuestionId values
            var questionIds = new List<int>();   
            foreach (var answer in set)
            {
                questionIds.Add(answer.QuestionId);
            }
            // Check to make sure there are no duplicates
            Assert.Distinct(questionIds);
        }
    }
}
