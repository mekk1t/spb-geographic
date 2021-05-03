using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Models.Hard;
using WebApplication.Models.Easy;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Easy(IList<EasyQuestionViewModel> questions)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CorrectAnswer == questions[i].SelectedAnswer)
                    correctAnswers++;
            }

            decimal correctRatio = (decimal)correctAnswers / (decimal)questions.Count;

            if (correctRatio > 0.8M)
                return View("Win");
            if (correctRatio > 0.5M && correctRatio <= 0.8M)
                return Ok();

            return View("Fail");
        }

        public IActionResult Medium() => View();

        public IActionResult Hard(IList<HardQuestionViewModel> questions)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CorrectAnswer == questions[i].SelectedAnswer)
                    correctAnswers++;
            }

            decimal correctRatio = (decimal)correctAnswers / (decimal)questions.Count;

            if (correctRatio > 0.8M)
                return View("Win");
            if (correctRatio > 0.5M && correctRatio <= 0.8M)
                return View("Neutral");

            return View("Fail");
        }
    }
}
