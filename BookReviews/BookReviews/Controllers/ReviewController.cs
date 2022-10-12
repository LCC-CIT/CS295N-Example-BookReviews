using Microsoft.AspNetCore.Mvc;

namespace BookReviews.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Review()
        {
            return View();
        }
    }
}
