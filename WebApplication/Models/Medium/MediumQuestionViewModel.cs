using System.Collections.Generic;

namespace WebApplication.Models.Medium
{
    public class MediumQuestionViewModel
    {
        /// <summary>
        /// Главное изображение вопроса: обложка.
        /// </summary>
        public string Thumbnail { get; set; }
        /// <summary>
        /// Пользовательский ввод.
        /// </summary>
        public string UserInput { get; set; }
        /// <summary>
        /// Сам вопрос, например "В каком районе находится эта достопримечательность?" или "Как называется эта станция метро?" итд
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// Набор правильных ответов.
        /// </summary>
        /// <remarks>
        /// Здесь могут быть несколько вариантов правильного ответа: синонимы, разный регистр, название "в народе" итд.
        /// </remarks>
        public List<string> PossibleAnswers { get; set; }
    }
}
