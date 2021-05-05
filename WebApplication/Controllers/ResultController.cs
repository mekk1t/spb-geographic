using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Models.Hard;
using WebApplication.Models.Easy;
using WebApplication.Models.Medium;
using WebApplication.Models;
using System;

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

            return ResultPage(correctAnswers, questions.Count);
        }

        public IActionResult Medium(IList<MediumQuestionViewModel> questions)
        {
            int correctAnswers = 0;
            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].PossibleAnswers.Contains(questions[i].UserInput.ToLower().Trim()))
                    correctAnswers++;
            }

            return ResultPage(correctAnswers, questions.Count);
        }

        public IActionResult Hard(IList<HardQuestionViewModel> questions)
        {
            int correctAnswers = 0;

            for (int i = 0; i < questions.Count; i++)
            {
                if (questions[i].CorrectAnswer == questions[i].SelectedAnswer)
                    correctAnswers++;
            }

            return ResultPage(correctAnswers, questions.Count);
        }

        private ViewResult ResultPage(int correctAnswers, int questionsCount)
        {
            decimal correctRatio = (decimal)correctAnswers / (decimal)questionsCount;

            var resultViewModel = new ResultViewModel
            {
                PercentRatio = (int)Math.Round(correctRatio * 100, 0),
                CorrectAnswersCount = correctAnswers,
                TotalQuestionsCount = questionsCount,
                ImageUrl = "/Results/fail.png"
            };

            if (correctRatio > 0.8M)
                resultViewModel.ImageUrl = "/Results/success.jpg";
            if (correctRatio > 0.5M && correctRatio <= 0.8M)
                resultViewModel.ImageUrl = "/Results/neutral.jpg";

            return View("Results", resultViewModel);
        }
    }
}
