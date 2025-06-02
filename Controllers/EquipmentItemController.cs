using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ErmakovAppDiplom.Controllers
{
    [Authorize]
    public class EquipmentItemController : Controller
    {
        private readonly IEquipmentItemRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISubLocationRepository _subLocationRepository;
        private readonly IUserRepository _userRepository;
        public EquipmentItemController(IEquipmentItemRepository repository, ICategoryRepository categoryRepository, ISubLocationRepository subLocationRepository, IUserRepository userRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _subLocationRepository = subLocationRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<EquipmentItem> equipmentItems = _repository.GetAll();
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.SubLocations = _subLocationRepository.GetAll();
            ViewBag.Employees = _userRepository.GetAll();


            ViewBag.FilterStatus = "";
            ViewBag.FilterCategoryId = 0;

            return View(equipmentItems);
        }

        public IActionResult Filter(EquipmentItemFilterViewModel itemFilter)
        {
            List<EquipmentItem> equipmentItems = _repository.GetAllByFilter(itemFilter);
            ViewBag.Categories = _categoryRepository.GetAll();
            ViewBag.SubLocations = _subLocationRepository.GetAll();
            ViewBag.Employees = _userRepository.GetAll();


            ViewBag.Search = itemFilter.Search;
            ViewBag.FilterStatus = itemFilter.FilterStatus;
            ViewBag.FilterCategoryId = itemFilter.FilterCategoryId;

            return View("Index", equipmentItems);
        }

        [HttpPost]
        public IActionResult Create(EquipmentItemCreateViewModel itemCreateVM)
        {
            EquipmentItem equipmentItem = new EquipmentItem
            {
                Name = itemCreateVM.Name,
                Model = itemCreateVM.Model,
                CategoryId = itemCreateVM.CategoryId,
                Category = _categoryRepository.GetById(itemCreateVM.CategoryId),
                Status = itemCreateVM.Status,
                InventoryNumber = itemCreateVM.InventoryNumber,
                SubLocation = !itemCreateVM.SubLocationId.Equals(0) ? _subLocationRepository.GetById(itemCreateVM.SubLocationId) : null,
                User = !itemCreateVM.UserId.Equals("null") ? _userRepository.GetById(itemCreateVM.UserId) : null
            };

            _repository.Create(equipmentItem);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(EquipmentItemUpdateViewModel equipmentItem)
        {
            EquipmentItem existItem = _repository.GetById(equipmentItem.Id);
            existItem.Name = equipmentItem.Name;
            existItem.Model = equipmentItem.Model;
            existItem.CategoryId = equipmentItem.CategoryId;
            existItem.Category = _categoryRepository.GetById(equipmentItem.CategoryId);
            existItem.Status = equipmentItem.Status;
            existItem.InventoryNumber = equipmentItem.InventoryNumber; 
            existItem.PositionX = equipmentItem.PositionX;
            existItem.PositionY = equipmentItem.PositionY;
            existItem.SubLocation = !equipmentItem.SubLocationId.Equals(null)
                ? _subLocationRepository.GetById(equipmentItem.SubLocationId.Value)
                : null;

            existItem.User = !equipmentItem.UserId.Equals("null")
                ? _userRepository.GetById(equipmentItem.UserId)
                : null;

            _repository.Update(existItem);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
