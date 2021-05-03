﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using WebApplication.DirectoryHandlers;
using WebApplication.Models;
using WebApplication.Models.Easy;

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
        public IActionResult Medium() => View();
        public IActionResult Hard() => View();

        public IActionResult Index()
        {
            // Пример задания входных данных и возвращения представления

            //var fileBytes1 = System.IO.File.ReadAllBytes("Images/01.png");
            //var file1 = Convert.ToBase64String(fileBytes1);
            //var fileBytes2 = System.IO.File.ReadAllBytes("Images/02.png");
            //var file2 = Convert.ToBase64String(fileBytes2);
            //var viewModels = new List<QuestionViewModel>
            //{
            //    new QuestionViewModel
            //    {
            //        ImageBase64 = file1,
            //        Options = new string[4]
            //        {
            //            "DOOM", "Wolfenstein", "Serious Sam", "The Sims"
            //        },
            //        CorrectAnswer = "DOOM"
            //    },
            //    new QuestionViewModel
            //    {
            //        ImageBase64 = file2,
            //        Options = new string[4]
            //        {
            //            "Ответ 1 ", "Ответ 2", "Ответ 3", "Ответ 4"
            //        },
            //        CorrectAnswer = "Ответ 1"
            //    },
            //};

            return View();
        }
    }
}
