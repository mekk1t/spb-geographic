using System.Collections.Generic;
using WebApplication.Models.Easy;
using WebApplication.Models.Hard;
using WebApplication.Models.Medium;

namespace WebApplication.Models
{
    public class ResultViewModel
    {
        public int PercentRatio { get; set; }
        public int CorrectAnswersCount { get; set; }
        public int TotalQuestionsCount { get; set; }
        public string ImageUrl { get; set; }

        public IList<HardQuestionViewModel> HardQuestions { get; set; }
        public IList<MediumQuestionViewModel> MediumQuestions { get; set; }
        public IList<EasyQuestionViewModel> EasyQuestions { get; set; }
    }
}
