using BookReviews.Controllers;
using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace BookReviewTests
{
    public class ReviewControllerTests
    {
        [Fact]
        public void IndexTest()
        {
            // arrange
            ReviewController controller = new ReviewController();
            const string TITLE = "The Title";
            const string REVIEW_TEXT = "Not a real book";

            // act
            ViewResult viewResult = (ViewResult)controller.Index( 
                TITLE,
                REVIEW_TEXT, 
                "Ann Author", 
                "Me", 
                DateTime.Now);

            Review model = (Review)viewResult.Model;

            // assert
            Assert.NotNull(viewResult);
            Assert.Equal(TITLE, model.Book.BookTitle);
            Assert.Equal(REVIEW_TEXT, model.ReviewText);

        }
    }
}
