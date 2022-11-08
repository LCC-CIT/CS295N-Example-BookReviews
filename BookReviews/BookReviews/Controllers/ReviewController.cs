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
        ApplicationDbContext context;
        public ReviewController(ApplicationDbContext c)
        {
            context = c;
        }

        // Can be called with or without a reviewId on the incoming http request
        public IActionResult Index(int reviewId) 
        {
            // If the http request doesn't have a reviewId, then reviewId = 0.
            var review = context.Reviews
                .Include(review => review.Reviewer) // returns Reivew.AppUser object
                .Include(review => review.Book) // returns Review.Book object
                .Where(review => review.ReviewId == reviewId)
                .SingleOrDefault();  // default is null
            // If no review is found, a null is sent to the view.
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
            return RedirectToAction("Index",new {reviewId = model.ReviewId});
        }
    }
}
