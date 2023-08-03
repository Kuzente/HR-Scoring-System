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
            var UsersWithIncludes = _userService.GetUsersWithDepartmantsAndTitle();                   
            var Branches = _branchService.TGetList();
            return View(new UserDto { Users = UsersWithIncludes , Branches = Branches });
        }
        [HttpPost]
        public IActionResult Add(UserDto dto)
        {                             
            foreach (var branchID in dto.BranchIds)
            {
                dto.Branches.Add(_branchService.TGetById(branchID));               
            }
            _userService.TAdd(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dto = _userService.GetUserWithDepartmantsAndTitle(id);
            dto.AllBranches = _branchService.TGetList();
        
            //ViewBag.BranchsSelectlist = _branchService.TGetList().Select(d => new SelectListItem // Tüm Departmanların Listelenmesi
            //{
            //    Text = d.Name,
            //    Value = d.ID.ToString(),
            //    Selected = dto.Branches.Any(u => u.ID == d.ID) // Kullanıcının bağlı oldugu suberlerin listelenip selected edilmesi
            //});
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(UserDto dto)
        {
         
            foreach (var branchID in dto.BranchIds)
            {
                dto.Branches.Add(_branchService.TGetById(branchID));
            }
            _userService.TUpdate(dto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _userService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _userService.ChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}
