using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class OfficeMapController : Controller
    {
        private IFloorRepository _floorRepository;
        private ISubLocationRepository _subLocationRepository;
        private ICategoryRepository _categoryRepository;
        private IEquipmentItemRepository _equipmentItemRepository;

        public OfficeMapController(IFloorRepository floorRepository, ISubLocationRepository subLocationRepository, ICategoryRepository categoryRepository, IEquipmentItemRepository equipmentItemRepository)
        {
            _floorRepository = floorRepository;
            _subLocationRepository = subLocationRepository;
            _categoryRepository = categoryRepository;
            _equipmentItemRepository = equipmentItemRepository;
        }

        public IActionResult Index()
        {
            List<Floor> floors = _floorRepository.GetAll();
            List<SubLocation> locations = _subLocationRepository.GetAll();
            List<Category> categories = _categoryRepository.GetAll();
            List<EquipmentItem> items = _equipmentItemRepository.GetAll().Where(e => e.SubLocation != null).ToList();
            ViewBag.Floors = floors;
            ViewBag.Locations = locations;
            ViewBag.Categories = categories;
            ViewBag.EquipmentItems = items;
            return View();
        }

        public IActionResult EditEquipment(OfficeMapEquipmentItemEditViewModel equipmentItem)
        {
            EquipmentItem existingItem = _equipmentItemRepository.GetById(equipmentItem.EquipmentItemId);
            existingItem.PositionX = equipmentItem.PositionX;
            existingItem.PositionY = equipmentItem.PositionY;
            existingItem.Status = equipmentItem.Status;
            existingItem.Name = equipmentItem.Name;

            _equipmentItemRepository.Update(existingItem);

            return RedirectToAction("Index");
        }
    }
}
