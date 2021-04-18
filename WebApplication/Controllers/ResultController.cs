using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class ResultController : Controller
    {
        /// <summary>
        /// Возвращает представление по завершении теста.
        /// </summary>
        /// <returns></returns>
        public IActionResult Complete() => View();

        /// <summary>
        /// Возвращает частичное представление с результатами на страницу теста, чтобы не перезагружать страницу.
        /// </summary>
        /// <remarks>
        /// Win, FiftyFifty и Fail - названия .cshtml-файлов в папке Views/Result/.
        /// </remarks>
        /// <param name="result">Высчитанный % завершения теста.</param>
        public IActionResult Stats(double result)
        {
            if (result >= 0.8)
            {
                return PartialView("Win");
            }

            if (result < 0.8 && result >= 0.5)
            {
                return PartialView("FiftyFifty");
            }

            return PartialView("Fail");
        }
    }
}
