using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Easy(IEnumerable<QuestionViewModel> results)
        {
            return View();
            // Пример обработки
            //var correctAnswersCount = results.Count(r => r.SelectedAnswer == r.CorrectAnswer);
            //var correctAnswersRatio = (double)correctAnswersCount / results.Count();

            //if (correctAnswersRatio >= 0.5)
            //{
            //    return View("Easy_Win");
            //}

            //return View("Easy");
        }

        public IActionResult Medium() => View();

        public IActionResult Hard() => View();
    }
}
