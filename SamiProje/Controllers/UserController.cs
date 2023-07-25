using AutoMapper;
using Business.Abstract;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SamiProje.Business.Abstract;

namespace SamiProje.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IDepartmantService _departmantService;
        private readonly IBranchService _branchService;

        public UserController(IUserService userService, IMapper mapper, IDepartmantService departmantService, IBranchService branchService)
        {
            _userService = userService;
            _mapper = mapper;
            _departmantService = departmantService;
            _branchService = branchService;
        }

        public IActionResult Index()
        {
            UserDto dto = new();

            dto.Users = _userService.GetUsersWithDepartmantsAndTitle(); // Index sayfasında userlara bağlı departmanların listelenmesi          
            //ViewBag.DepartmantsSelectlist = _departmantService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            //{
            //    Text = d.Name,
            //    Value = d.ID.ToString(),                
            //});
            ViewBag.BranchesSelectlist = _branchService.TGetList().Select(d => new SelectListItem // Tüm Şubelerin Listelenmesi
            {
                Text = d.Name,
                Value = d.ID.ToString(),
            });
            

            return View(dto);
        }
        [HttpPost]
        public IActionResult Add(UserDto dto)
        {                   
            //foreach (var departmantID in dto.DepartmantIds)
            //{
            //     dto.Departmants.Add(_departmantService.TGetById(departmantID));
            //    // gelen departmanları getiriyor
            //}
            foreach (var branchID in dto.BranchIds)
            {
                dto.Branches.Add(_branchService.TGetById(branchID));
                // gelen departmanları getiriyor
            }
            var model = _mapper.Map<User>(dto);
            _userService.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dto = _mapper.Map<UserDto>(_userService.GetUserWithDepartmantsAndTitle(id));
            
            //ViewBag.DepartmantsSelectlist = _departmantService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            //{
            //    Text = d.Name,
            //    Value = d.ID.ToString(),
            //    Selected = dto.Departmants.Any(u => u.ID == d.ID) // Kullanıcının bağlı oldugu departmanların listelenip selected edilmesi
            //});
            ViewBag.BranchsSelectlist = _branchService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            {
                Text = d.Name,
                Value = d.ID.ToString(),
                Selected = dto.Branches.Any(u => u.ID == d.ID) // Kullanıcının bağlı oldugu departmanların listelenip selected edilmesi
            });
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(UserDto dto)
        {
    
            //foreach (var departmantID in dto.DepartmantIds)
            //    {
            //        dto.Departmants.Add(_departmantService.TGetById(departmantID));
            //        // gelen departmanları getiriyor
            //    }
            foreach (var branchID in dto.BranchIds)
            {
                dto.Branches.Add(_branchService.TGetById(branchID));
                // gelen departmanları getiriyor
            }

            var model = _mapper.Map<User>(dto);
            _userService.TUpdate(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _userService.TGetById(id);
            _userService.TDelete(model);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _userService.ChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}
