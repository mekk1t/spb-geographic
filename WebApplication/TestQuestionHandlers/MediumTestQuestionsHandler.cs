using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using WebApplication.Models.Medium;

namespace WebApplication.TestQuestionHandlers
{
    public class MediumTestQuestionsHandler
    {
        private readonly string _directory;

        public MediumTestQuestionsHandler(string directory)
        {
            _directory = directory;
        }

        public List<MediumQuestionViewModel> GetQuestions()
        {
            var result = new List<MediumQuestionViewModel>();
            try
            {
                string[] questionsList = Directory.GetFiles($"{_directory}/Questions", "*.json");
                foreach (var question in questionsList)
                    result.Add(JsonConvert.DeserializeObject<MediumQuestionViewModel>(File.ReadAllText(question)));
            }
            catch (Exception e)
            {
                Console.WriteLine("Отсутствуют необходимые папки");
            }
            return result;
        }
    }
}
