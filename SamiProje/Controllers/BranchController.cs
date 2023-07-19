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
            var model = _mapper.Map<Branch>(dto);
            _branchService.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dto = _mapper.Map<BranchDto>(_branchService.TGetById(id));
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(BranchDto dto)
        {
            var model = _mapper.Map<Branch>(dto);
            _branchService.TUpdate(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var model = _branchService.TGetById(id);
            _branchService.TDelete(model);
            return RedirectToAction("Index");
        }
    }
}
