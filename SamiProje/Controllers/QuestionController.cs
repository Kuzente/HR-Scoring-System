using AutoMapper;
using Business.Abstract;
using DTO;
using DTO.Abstract;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SamiProje.Controllers
{
    public class QuestionController : Controller
    {
        
        private readonly ITitleService _titleDtoService;
        private readonly ITitleQuestionService _questionDtoService;
        public QuestionController(ITitleQuestionService questionDtoService, ITitleService titleDtoService)
        {
            _questionDtoService = questionDtoService;
            _titleDtoService = titleDtoService;
        }
        public IActionResult Index(int id = 0)
        {
            var titles = _titleDtoService.TGetList();
            if (id > 0)
            {
                var questsById = _questionDtoService.GetQuestionsByTitleID(id);
                var title = _titleDtoService.TGetById(id);
                return View(new TitleQuestionDto { Titles = titles, TitleQuestions = questsById , Title = title });
            }
            return View(new TitleQuestionDto { Titles = titles });
        }               
        [HttpGet]
        public IActionResult GetQuestions(TitleQuestionDto model)
        {
            var Id = model.Title.ID;
            return RedirectToAction("Index" , new { id = Id });
        }
        [HttpPost]
        public IActionResult Add(TitleQuestionDto dto)
        {            
            _questionDtoService.TAdd(dto);
            return Redirect(dto.ReturnUrl);
        }
        [HttpPost]
        public IActionResult Delete(int id , string returnUrl)
        {
            _questionDtoService.TDelete(id);
            return Redirect(returnUrl);
        }
        [HttpGet]
        public IActionResult Update(int id , string returnUrl)
        {
            var dto = _questionDtoService.TGetById(id);
            dto.ReturnUrl = returnUrl;
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(TitleQuestionDto dto)
        {
            _questionDtoService.TUpdate(dto);
            return Redirect(dto.ReturnUrl);
        }
       
        public IActionResult ChangeStatus(int id, string returnUrl)
        {
            _questionDtoService.ChangeStatus(id);
            return Redirect(returnUrl);
        }
    }
}
