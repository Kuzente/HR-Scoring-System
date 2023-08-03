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
        private readonly IBranchService _branchDtoService;
        public BranchController(IBranchService branchDtoService)
        {
            _branchDtoService = branchDtoService;
        }
        public IActionResult Index()
        { 
            return View(new BranchDto { Branches = _branchDtoService.TGetList() });
        }
        [HttpPost]
        public IActionResult Add(BranchDto dto)
        {
            _branchDtoService.TAdd(dto);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var dto = _branchDtoService.TGetById(id);
            return View(dto);
        }
        [HttpPost]
        public IActionResult Update(BranchDto dto)
        {
            _branchDtoService.TUpdate(dto);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _branchDtoService.TDelete(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatus(int id)
        {
            _branchDtoService.ChangeStatus(id);
            return RedirectToAction("Index");
        }
    }
}
