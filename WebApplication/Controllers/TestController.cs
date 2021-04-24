using Microsoft.AspNetCore.Mvc;
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
            var handler = new TestQuestionsHandler("Images/Hard/Petrogradskiy");
            var questions = handler.GetQuestions();
            return View(questions);
        }
    }
}
