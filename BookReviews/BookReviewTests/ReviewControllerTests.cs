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
            // arrange: nothing to do - all done at class scope

            // act
            ViewResult viewResult = (ViewResult)controller.Index( 
                TITLE,
                REVIEW_TEXT, 
                AUTHOR, 
                REVIEWER, 
                DateTime.Now);

            Review model = (Review)viewResult.Model;

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(TITLE, model.Book.BookTitle);
            Assert.Equal(REVIEW_TEXT, model.ReviewText);
            // TODO: Add asserts for the rest fo the model properties
        }

        [Fact]
        public void Review_PostTest()
        {
            // arrange
            Review model = new Review
            {
                Book = new Book { BookTitle = TITLE, AuthorName = AUTHOR },
                ReviewText = REVIEW_TEXT,
                ReviewDate = DateTime.Now,
                Reviewer = new AppUser { UserName = REVIEWER }
            };

            // act
            var redirectResult = (RedirectToActionResult)controller.Review(model);
            var routeValueDict = (RouteValueDictionary)redirectResult.RouteValues;


            // assert
            // Keys to the RouteValueDictionary come from the properties of the
            // routeValues Object passed to the RedirectToAction method in the method
            // being tested.
            Assert.Equal(TITLE, routeValueDict["bookTitle"]);
            Assert.Equal(REVIEW_TEXT, routeValueDict["reviewText"]);
            // TODO: Write asserts for the rest of the route values
        }
    }
}
