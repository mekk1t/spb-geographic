using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Index(IEnumerable<QuestionViewModel> results)
        {
            var correctAnswersCount = results.Count(r => r.SelectedAnswer == r.CorrectAnswer);
            var correctAnswersRatio = (double)correctAnswersCount / results.Count();

            if (correctAnswersRatio >= 0.5)
            {
                return View("Pass");
            }

            return View("Fail");
        }
    }
}
