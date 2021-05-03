using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Hard;
using System.Collections.Generic;
using System.IO;
using WebApplication.DirectoryHandlers;
using WebApplication.Models.Easy;
using WebApplication.Models.Medium;
using WebApplication.TestQuestionHandlers;

namespace WebApplication.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Easy()
        {
            var easySubDirectories = Directory.GetDirectories("Images/Easy");
            var questions = new List<EasyQuestionViewModel>();
            foreach (var easySubDirectory in easySubDirectories)
            {
                var handler = new EasyTestQuestionsHandler(easySubDirectory);
                questions.AddRange(handler.GetQuestions());
            }
            return View(questions);
        }

        public IActionResult Medium()
        {
            var mediumSubDirectories = Directory.GetDirectories("Images/Medium");
            var questions = new List<MediumQuestionViewModel>();
            foreach (var subDirectory in mediumSubDirectories)
            {
                var handler = new MediumTestQuestionsHandler(subDirectory);
                questions.AddRange(handler.GetQuestions());
            }

            return View(questions);
        }

        public IActionResult Hard()
        {
            var hardSubDirectories = Directory.GetDirectories("Images/Hard");
            var questions = new List<HardQuestionViewModel>();
            foreach (var hardSubDirectory in hardSubDirectories)
            {
                var handler = new HardTestQuestionsHandler(hardSubDirectory);
                questions.AddRange(handler.GetQuestions());
            }

            return View(questions);
        }
    }
}
