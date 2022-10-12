using Microsoft.AspNetCore.Mvc;

namespace BookReviews.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}