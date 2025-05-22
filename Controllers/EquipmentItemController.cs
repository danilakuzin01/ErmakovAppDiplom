using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    [Authorize]
    public class EquipmentItemController : Controller
    {
        private readonly IEquipmentItemRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;
        public EquipmentItemController(IEquipmentItemRepository repository, ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<EquipmentItem> equipmentItems = _repository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.Employees = _userRepository.GetAll();

            return View(equipmentItems);
        }

        public IActionResult Details(int id)
        {
            EquipmentItem equipmentItem = _repository.GetById(id);
            if (equipmentItem == null)
            {
                return NotFound();
            }
            return View(equipmentItem);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EquipmentItem equipmentItem)
        {
            EquipmentItem equipment = new EquipmentItem();
            equipment.Name = equipmentItem.Name;
            equipment.Category = _categoryRepository.GetById(equipmentItem.CategoryId);

            _repository.Create(equipment);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(EquipmentItem equipmentItem)
        {
            EquipmentItem existItem = _repository.GetById(equipmentItem.Id);
            if (!existItem.Name.Equals(equipmentItem.Name))
            {
                existItem.Name = equipmentItem.Name;
            }
            if (existItem.CategoryId != equipmentItem.CategoryId)
            {
                existItem.CategoryId = equipmentItem.CategoryId;
                existItem.Category = _categoryRepository.GetById(equipmentItem.CategoryId);
            }
            _repository.Update(existItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
