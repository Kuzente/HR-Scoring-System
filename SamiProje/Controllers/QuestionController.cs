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
        private readonly ITitleQuestionService _questionService;
        private readonly ITitleService _titleService;
        private readonly IMapper _mapper;
        public QuestionController(ITitleQuestionService questionService, ITitleService titleService, IMapper mapper)
        {
            _questionService = questionService;
            _titleService = titleService;
            _mapper = mapper;
        }
        public IActionResult Index(int id = 0)
        {
            TitleQuestionDto dto = new TitleQuestionDto();

            dto.TitlesHaveQuestions = _titleService.TGetList();       
            if (id > 0)
            {
                dto.TitleQuestions = _questionService.GetListByFilter(p => p.TitleID == id);
                dto.Title = _titleService.TGetById(id);
            }        
            return View(dto);
        }               
        [HttpGet]
        public IActionResult GetQuestions(TitleQuestionDto model)
        {
            var id = model.Title.ID;
            return RedirectToAction("Index" , new { id = id });
        }
        [HttpPost]
        public IActionResult Add(TitleQuestionDto dto)
        {            
            _questionService.TAdd(_mapper.Map<TitleQuestion>(dto));
            return Redirect(dto.ReturnUrl);
        }
        [HttpPost]
        public IActionResult Delete(int id , string returnUrl)
        {
            _questionService.TDelete(_questionService.TGetById(id));
            return Redirect(returnUrl);
        }
        [HttpGet]
        public IActionResult Update(int id , string returnUrl)
        {
            var dto = _mapper.Map<TitleQuestionDto>(_questionService.TGetById(id));
            dto.ReturnUrl = returnUrl;
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(TitleQuestionDto dto)
        {
            _questionService.TUpdate(_mapper.Map<TitleQuestion>(dto));
            return Redirect(dto.ReturnUrl);
        }
       
        public IActionResult ChangeStatus(int id, string returnUrl)
        {
            _questionService.ChangeStatus(id);
            return Redirect(returnUrl);
        }
    }
}
