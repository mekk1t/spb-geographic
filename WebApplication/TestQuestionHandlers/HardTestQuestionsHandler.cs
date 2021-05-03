using Medallion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication.Models.Hard;

namespace WebApplication.DirectoryHandlers
{
    public class HardTestQuestionsHandler
    {
        private readonly string _directory;

        public HardTestQuestionsHandler(string directory)
        {
            _directory = directory;
        }

        public List<HardQuestionViewModel> GetQuestions()
        {
            var subDirectories = Directory.GetDirectories(_directory);
            var result = new List<HardQuestionViewModel>();
            foreach (var subDirectory in subDirectories)
            {
                var screenshotsFilePaths = Directory.GetFiles($"{subDirectory}/Screenshots");
                var options = screenshotsFilePaths.Select(filePath => GetBase64File(filePath)).ToList();
                options.Shuffle();
                result.Add(new HardQuestionViewModel
                {
                    Thumbnail = GetBase64File($"{subDirectory}/image.jpg"),
                    CorrectAnswer = GetBase64File($"{subDirectory}/Screenshots/correct.jpg"),
                    Options = options
                });
            }

            return result;
        }

        private static string GetBase64File(string filePath)
            => Convert.ToBase64String(File.ReadAllBytes(filePath));
    }
}
