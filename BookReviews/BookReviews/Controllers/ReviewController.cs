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

        // Can be called with or without a reviewId on the incoming http request
        public IActionResult Index(int reviewId) 
        {
            Review review = repo.GetReviewById(reviewId);
            return View(review);
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
