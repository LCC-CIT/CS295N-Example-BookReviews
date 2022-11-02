using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;

namespace BookReviews.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index(string bookTitle, 
                                    string reviewText,
                                    string authorName,
                                    string reviewerName,
                                    DateTime date) 
        {
            Review review = new Review();
            review.ReviewDate = date;
            review.ReviewText = reviewText;
            AppUser reviewer = new AppUser();
            reviewer.UserName = reviewerName;
            Book book = new Book();
            book.BookTitle = bookTitle;
            book.AuthorName = authorName;
            review.Book = book;
            review.Reviewer = reviewer;
            return View(review);
        }


        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            return RedirectToAction("Index",
                new
                {
                    bookTitle = model.Book.BookTitle,
                    reviewText = model.ReviewText,
                    authorName = model.Book.AuthorName,
                    reviewerName = model.Reviewer.UserName,
                    date = DateTime.Now
                }
            );
        }
    }
}
