﻿using Microsoft.AspNetCore.Mvc;

namespace BookReviews.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
