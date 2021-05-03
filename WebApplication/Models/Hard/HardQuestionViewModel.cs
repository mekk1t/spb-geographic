using System.Collections.Generic;

namespace WebApplication.Models.Hard
{
    public class HardQuestionViewModel
    {
        public string Thumbnail { get; set; }
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public string SelectedAnswer { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
