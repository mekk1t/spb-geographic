using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication.Models.Hard;

namespace WebApplication.DirectoryHandlers
{
    public class TestQuestionsHandler
    {
        private readonly string _directory;

        public TestQuestionsHandler(string directory)
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
                result.Add(new HardQuestionViewModel
                {
                    Thumbnail = GetBase64File($"{subDirectory}/image.jpg"),
                    CorrectAnswer = GetBase64File($"{subDirectory}/Screenshots/correct.jpg"),
                    Options = screenshotsFilePaths.Select(filePath => GetBase64File(filePath)).ToList()
                });
            }

            return result;
        }

        private string GetBase64File(string filePath)
            => Convert.ToBase64String(File.ReadAllBytes(filePath));
    }
}
