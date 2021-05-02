using System.Text.Json.Serialization;

namespace WebApplication.Models.Easy
{
    public class EasyQuestionViewModel
    {
        public string Question { get; set; }
        public string[] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string SelectedAnswer { get; set; }
        public string ImageBase64 { get; set; }
    }
}
