using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace SamiProje.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ITitleQuestionService _questionService;

        public QuestionController(ITitleQuestionService questionService)
        {
            _questionService = questionService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
