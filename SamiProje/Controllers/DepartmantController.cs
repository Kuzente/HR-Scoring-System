using AutoMapper;
using Business.Abstract;
using DTO;
using Entity;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using SamiProje.Business.Abstract;
using SamiProje.Models;

namespace SamiProje.Controllers
{
	public class DepartmantController : Controller
	{
		private readonly IDepartmantService _departmantDtoService;
		

        public DepartmantController(IDepartmantService departmantDtoService)
        {
            _departmantDtoService = departmantDtoService;
            
        }
        public IActionResult Index()
		{ 		
			return View(new DepartmantDto { Departmants = _departmantDtoService.TGetList()});
		}
		public IActionResult Add(DepartmantDto dto)
		{
            _departmantDtoService.TAdd(dto);			
			return RedirectToAction("Index");
		}
		[HttpGet]
        public IActionResult Update(int id)
        {          
            var dto = _departmantDtoService.TGetById(id);
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(DepartmantDto dto)
        {
            _departmantDtoService.TUpdate(dto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _departmantDtoService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _departmantDtoService.ChangeStatus(id);       
            return RedirectToAction("Index");
        }
    }
}
