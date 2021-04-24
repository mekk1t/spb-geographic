using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using WebApplication.Models;
using WebApplication.Models.Hard;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult Easy(IEnumerable<QuestionViewModel> results)
        {
            return View();
        }

        public IActionResult Medium() => View();

        public IActionResult Hard(IList<HardQuestionViewModel> questions)
        {
            Dictionary<int, bool> results = new();

            for (int i = 0; i < questions.Count; i++)
            {
                results.Add(i, questions[i].CorrectAnswer == questions[i].SelectedAnswer);
            }

            return Json(results, new JsonSerializerOptions
            {
                WriteIndented = true
            });
        }
    }
}
