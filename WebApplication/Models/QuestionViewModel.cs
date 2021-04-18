namespace WebApplication.Models
{
    public class QuestionViewModel
    {
        public string ImageBase64 { get; set; }
        public string[] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
