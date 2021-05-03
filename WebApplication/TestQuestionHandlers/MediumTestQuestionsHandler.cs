using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string[] questionsList = Directory.GetFiles($"{_directory}/Questions", "*.json");
            foreach (var question in questionsList)
            {
                var viewModel = JsonConvert.DeserializeObject<MediumQuestionViewModel>(File.ReadAllText(question));
                viewModel.PossibleAnswers = viewModel.PossibleAnswers.Select(answer => answer.ToLower().Trim()).ToList();
                result.Add(viewModel);
            }
            return result;
        }
    }
}
