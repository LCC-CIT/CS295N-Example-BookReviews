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
            model.RightOrWrong1 = BookReviews.Quiz.CheckAnswer(1, model.UserAnswer1);
            model.RightOrWrong2 = BookReviews.Quiz.CheckAnswer(2, model.UserAnswer2);
            model.RightOrWrong3 = BookReviews.Quiz.CheckAnswer(3, model.UserAnswer3);
            return View(model);
        }
    }
}