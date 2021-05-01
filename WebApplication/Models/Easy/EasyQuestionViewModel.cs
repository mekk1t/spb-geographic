using System.Text.Json.Serialization;

namespace WebApplication.Models.Easy
{
    /// <summary>
    /// Пример модели вопроса в тесте. Может разниться, в зависимости от типа представления.
    /// К примеру, здесь Options - массив строк, т.к. модель для выбора одного варианта из нескольких.
    /// В модели для теста средней сложности этого поля может и не быть, т.к. придется вводить данные вручную.
    /// </summary>
    public class EasyQuestionViewModel
    {
        public string ImageBase64 { get; set; }
        public string[] Options { get; set; }
        public string CorrectAnswer { get; set; }
        public string SelectedAnswer { get; set; }
    }
}
