using BookReviews.Controllers;
using BookReviews.Data;
using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace BookReviewTests
{
    public class ReviewControllerTests
    {
        IReviewRepository repo = new FakeReviewRepository();
        ReviewController controller;
        /* Not needed now
        const string TITLE = "The Title";
        const string REVIEW_TEXT = "Not a real book";
        const string AUTHOR = "Anne Author";
        const string REVIEWER = "I. M. Me";
        */

        public ReviewControllerTests()
        {
           controller = new ReviewController(repo);
        }

        /*
        [Fact]
        public void IndexTest()
        {
            // arrange: not much to do - mostly done at class scope
            var dateTime = DateTime.Now;  // need to save for comparison in assert

            // act
            ViewResult viewResult = (ViewResult)controller.Index( 
                TITLE,
                REVIEW_TEXT, 
                AUTHOR, 
                REVIEWER, 
                dateTime);

            Review model = (Review)viewResult.Model;

            // assert
            Assert.Equal(TITLE, model.Book.BookTitle);
            Assert.Equal(REVIEW_TEXT, model.ReviewText);
            Assert.Equal(AUTHOR, model.Book.AuthorName);
            Assert.Equal(REVIEWER, model.Reviewer.UserName);
            Assert.Equal(dateTime, model.ReviewDate);
        }
        */

        [Fact]
        public void Review_PostTest_Success()
        {
            // arrange
            // Done in the constructor

            // act
            var result = controller.Review(new Review());

            // assert
            // Check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(RedirectToActionResult));
        }

        [Fact]
        public void Review_PostTest_Failure()
        {
            // arrange
            // Done in the constructor

            // act
            var result = controller.Review(null);

            // assert
            // Check to see if I got a RedirectToActionResult
            Assert.True(result.GetType() == typeof(ViewResult));
        }

    }
}
