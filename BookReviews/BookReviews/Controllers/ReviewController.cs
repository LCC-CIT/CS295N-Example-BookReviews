using BookReviews.Data;
using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReviews.Controllers
{
    public class ReviewController : Controller
    {
        IReviewRepository repo;
        public ReviewController(IReviewRepository r)
        {
            repo = r;
        }

        public IActionResult Index(string ReviewerName, string BookTitle) 
        {
            List<Review> reviews;

            // ReviewerName is not null
            if (ReviewerName != null)
            {
                reviews = (
                    from r in repo.Reviews
                    where r.Reviewer.UserName == ReviewerName
                    select r
                    ).ToList<Review>();
            }
            // BookTitle is not null
            else if (BookTitle != null)
            {
                reviews = (
                    from r in repo.Reviews
                    where r.Book.BookTitle == BookTitle
                    select r
                    ).ToList<Review>();
            }
            // Both query parameters are null
            else
            {
                reviews = repo.Reviews.ToList<Review>();
            }

            return View(reviews);
        }


        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            if (repo.StoreReview(model) > 0)
            {
                return RedirectToAction("Index", new { reviewId = model.ReviewId });
            }
            else
            {
                return View();  // TODO: Send an error message to the view
            }
        }
    }
}
