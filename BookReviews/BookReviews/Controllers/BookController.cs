using BookReviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookReviews.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quiz()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quiz(QuizVM model)
        {
            return View(model);
        }
    }
}