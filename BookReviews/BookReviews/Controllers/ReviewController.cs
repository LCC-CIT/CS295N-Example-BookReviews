using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviews.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
                        return View();
        }

        // change the index view to show a review.

        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Review(Review model)
        {
            // need to do something with the data in the model
            return RedirectToAction("Index", model);  
        }
    }
}
