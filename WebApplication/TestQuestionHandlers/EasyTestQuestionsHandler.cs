using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Models.Easy;

namespace WebApplication.DirectoryHandlers
{
    public class EasyTestQuestionsHandler
    {
        private readonly string _directory;

        public EasyTestQuestionsHandler(string directory)
        {
            _directory = directory;
        }

        public List<EasyQuestionViewModel> GetQuestions()
        {
            var result = new List<EasyQuestionViewModel>();

            try
            {
                string[] questionsList = Directory.GetFiles($"{_directory}/Questions", "*.json");
                Console.WriteLine(questionsList[0]);
                foreach (var question in questionsList)
                {
                    result.Add(JsonConvert.DeserializeObject<EasyQuestionViewModel>(File.ReadAllText(question)));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Отсутствуют необходимые папки");
            }
            return result;
        }
    }
}
