using BookReviews.Controllers;
using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using Xunit;

namespace BookReviewTests
{
    public class ReviewControllerTests
    {
        ReviewController controller = new ReviewController();
        const string TITLE = "The Title";
        const string REVIEW_TEXT = "Not a real book";
        const string AUTHOR = "Anne Author";
        const string REVIEWER = "I. M. Me";

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

        [Fact]
        public void Review_PostTest()
        {
            // arrange

            Review model = new Review
            {
                Book = new Book { BookTitle = TITLE, AuthorName = AUTHOR },
                ReviewText = REVIEW_TEXT,
                Reviewer = new AppUser { UserName = REVIEWER }
            };
            // The ReviewDate property will be set by the Review method.

            // act
            var redirectResult = (RedirectToActionResult)controller.Review(model);
            var routeValueDict = (RouteValueDictionary)redirectResult.RouteValues;

            // assert
            // Keys to the RouteValueDictionary come from the properties of the
            // routeValues Object passed to the RedirectToAction method in the method
            // being tested.
            Assert.Equal(TITLE, routeValueDict["bookTitle"]);
            Assert.Equal(REVIEW_TEXT, routeValueDict["reviewText"]);
            Assert.Equal(AUTHOR, routeValueDict["authorName"]);
            Assert.Equal(REVIEWER, routeValueDict["reviewerName"]);
            Assert.Equal(DateTime.Now.Date, ((DateTime)routeValueDict["date"]).Date);
        }
    }
}
