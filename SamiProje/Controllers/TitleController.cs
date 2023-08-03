using AutoMapper;
using Business.Abstract;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.JSInterop.Infrastructure;
using SamiProje.Business.Abstract;

namespace SamiProje.Controllers
{
    public class TitleController : Controller
    {
        private readonly ITitleService _titleDtoService;
        private readonly IDepartmantService _departmantDtoService;


        public TitleController(ITitleService titleDtoService, IDepartmantService departmantDtoService)
        {
            _titleDtoService = titleDtoService;
            _departmantDtoService = departmantDtoService;
        }
        public IActionResult Index()
        {        
            var departmants = _departmantDtoService.TGetList()
                                                    .OrderBy(p=> p.Name)
                                                    .ToList();
            return View(new TitleDto { Titles = _titleDtoService.GetTitlesWithDepartmant() , Departmants = departmants});
        }
        [HttpPost]
        public IActionResult Add(TitleDto dto)
        {
            _titleDtoService.TAdd(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {         
            var model = _titleDtoService.GetTitleWithDepartmant(id);
            var departmants = _departmantDtoService.TGetList()
                                                    .OrderBy(p => p.Name)
                                                    .ToList();
            model.Departmants = departmants;
            return View(model);
        }
        [HttpPost]
        public IActionResult Update(TitleDto dto)
        {
            _titleDtoService.TUpdate(dto);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _titleDtoService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _titleDtoService.ChangeStatus(id);
            return RedirectToAction("Index");
        }

    }
}
