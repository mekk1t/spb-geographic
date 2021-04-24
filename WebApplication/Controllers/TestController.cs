using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using WebApplication.DirectoryHandlers;
using WebApplication.Models.Hard;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Easy() => View();
        public IActionResult Medium() => View();
        public IActionResult Hard()
        {
            var hardSubDirectories = Directory.GetDirectories("Images/Hard");
            var questions = new List<HardQuestionViewModel>();
            foreach (var hardSubDirectory in hardSubDirectories)
            {
                var handler = new TestQuestionsHandler(hardSubDirectory);
                questions.AddRange(handler.GetQuestions());
            }
            return View(questions);
        }
    }
}
