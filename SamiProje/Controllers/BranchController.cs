using AutoMapper;
using Business.Abstract;
using DTO;
using Entity;
using Microsoft.AspNetCore.Mvc;
using SamiProje.Business.Abstract;

namespace SamiProje.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            _branchService = branchService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            BranchDto dto = new();
            dto.Branches = _branchService.TGetList();
            return View(dto);
        }
        [HttpPost]
        public IActionResult Add(BranchDto dto)
        {          
            _branchService.TAdd(_mapper.Map<Branch>(dto));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_mapper.Map<BranchDto>(_branchService.TGetById(id)));
        }
        [HttpPost]
        public IActionResult Update(BranchDto dto)
        {
            _branchService.TUpdate(_mapper.Map<Branch>(dto));
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _branchService.TDelete(_branchService.TGetById(id));
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _branchService.ChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}
