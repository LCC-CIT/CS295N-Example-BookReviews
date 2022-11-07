using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BookReviews.Controllers
{
    public class ReviewController : Controller
    {
        ApplicationDbContext context;
        public ReviewController(ApplicationDbContext c)
        {
            context = c;
        }

        public IActionResult Index(string reviewId) 
        {
            Review review = new Review();
            /*
            review.ReviewDate = date;
            review.ReviewText = reviewText;
            AppUser reviewer = new AppUser();
            reviewer.UserName = reviewerName;
            Book book = new Book();
            book.BookTitle = bookTitle;
            book.AuthorName = authorName;
            review.Book = book;
            review.Reviewer = reviewer;
            */
            review = context.Reviews.First();
            return View(review);
        }


        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            model.ReviewDate = DateTime.Now;
            context.Reviews.Add(model);
            context.SaveChanges(); 

            /*
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
            */
            return RedirectToAction("Index",new {reviewId = model.ReviewId});
        }
    }
}
