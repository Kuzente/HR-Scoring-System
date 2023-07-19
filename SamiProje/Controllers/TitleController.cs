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
        private readonly ITitleService _titleService;
        private readonly IDepartmantService _departmantService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TitleController(ITitleService titleService, IDepartmantService departmantService, IMapper mapper, IUserService userService)
        {
            _titleService = titleService;
            _departmantService = departmantService;
            _mapper = mapper;
            _userService = userService;
        }

        public IActionResult Index()
        {
            TitleDto dto = new();
            dto.Titles = _titleService.TGetList();
            ViewBag.DepartmantsSelectlist = _departmantService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            {
                Text = d.Name,
                Value = d.ID.ToString(),
                
            });
            ViewBag.UsersSelectlist = _userService.TGetList()
                .Where(p => !dto.Titles
                    .Any(a => a.UserID == p.ID))
                        .Select(d => new SelectListItem 
            // Kullancılar tablosunda sadece ünvanı olmayan kullanıcıları çekiyoruz ki aynı kullanıcıya iki ünvan girilemesin!!!
            {
                Text = d.Username,
                Value = d.ID.ToString(),

            });
                
            return View(dto);
        }
        [HttpPost]
        public IActionResult Add(TitleDto dto)
        {
            var model = _mapper.Map<Title>(dto);
            _titleService.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dto = _mapper.Map<TitleDto>(_titleService.TGetById(id));
            ViewBag.DepartmantsSelectlist = _departmantService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            {
                Text = d.Name,
                Value = d.ID.ToString(),
                
            });
            // Kullancılar tablosunda sadece ünvanı olmayan kullanıcıları çekiyoruz ki aynı kullanıcıya iki ünvan girilemesin!!!
            ViewBag.UsersSelectlist = _userService.TGetList()
                .Where(p => !_titleService.TGetList()
                .Any(a => a.UserID == p.ID))
                .Select(d => new SelectListItem
            
            {
                Text = d.Username,
                Value = d.ID.ToString(),
                
                
            });
            if (ViewBag.UsersSelectlist == null)
            {
                ViewBag.UsersSelectlist = dto.User.Username;
            }
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(TitleDto dto)
        {
            var model = _mapper.Map<Title>(dto);
            model.Departmant = _departmantService.TGetById(model.Departmant.ID);
            _titleService.TUpdate(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {        
            _titleService.TDelete(_titleService.TGetById(id));
            return RedirectToAction("Index");
        }

    }
}
