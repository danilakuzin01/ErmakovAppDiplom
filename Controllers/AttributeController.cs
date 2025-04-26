using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;
using ErmakovAppDiplom.Models;
using Attribute = ErmakovAppDiplom.Models.Attribute;
using ErmakovAppDiplom.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace ErmakovAppDiplom.Controllers
{
    [Authorize]
    public class AttributeController : Controller
    {
        private readonly IAttributeRepository _attributeRepository;
        private readonly ICategoryRepository _categoryRepository;

        public AttributeController(IAttributeRepository attributeRepo, ICategoryRepository categoryRepo)
        {
            _attributeRepository = attributeRepo;
            _categoryRepository = categoryRepo;
        }

        public IActionResult Index()
        {
            var attributes = _attributeRepository.GetAll();
            return View(attributes);
        }

        [HttpPost]
        public IActionResult Create(AttributeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _categoryRepository.GetAll();
                return View("Index", _attributeRepository.GetAll()); // вернёмся к списку
            }

            var attr = new Attribute
            {
                Name = vm.Name,
                Category = _categoryRepository.GetById(vm.CategoryId)
            };

            _attributeRepository.Create(attr);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(AttributeViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = _categoryRepository.GetAll();
                return View("Index", _attributeRepository.GetAll());
            }

            var attr = _attributeRepository.GetById(vm.Id);
            if (attr != null)
            {
                attr.Name = vm.Name;
                attr.Category = _categoryRepository.GetById(vm.CategoryId);
                _attributeRepository.Update(attr);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _attributeRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetAttribute(int id)
        {
            var attr = _attributeRepository.GetById(id);
            if (attr == null) return NotFound();

            return Json(new
            {
                attr.Id,
                attr.Name,
                CategoryId = attr.Category?.Id
            });
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepository.GetAll();
            return Json(categories);
        }
    }
}
