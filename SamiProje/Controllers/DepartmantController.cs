using AutoMapper;
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
		private readonly IDepartmantService _departmantService;
		private readonly IMapper _mapper;

        public DepartmantController(IDepartmantService departmantService, IMapper mapper)
        {
            _departmantService = departmantService;
            _mapper = mapper;
        }
        public IActionResult Index()
		{
            DepartmantDto dto = new();
            dto.Departmants = _departmantService.TGetList();            			
			return View(dto);
		}
		public IActionResult Add(DepartmantDto dto)
		{
            var model = _mapper.Map<Departmant>(dto);						
			_departmantService.TAdd(model);			
			return RedirectToAction("Index");
		}
		[HttpGet]
        public IActionResult Update(int id)
        {          
            var dto = _mapper.Map<DepartmantDto>(_departmantService.TGetById(id));
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(DepartmantDto dto)
        {
            var model = _mapper.Map<Departmant>(dto);
            _departmantService.TUpdate(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _departmantService.TGetById(id);
			_departmantService.TDelete(model);
            return RedirectToAction("Index");
        }
    }
}
