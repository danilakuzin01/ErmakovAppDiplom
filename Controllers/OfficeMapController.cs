using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class OfficeMapController : Controller
    {
        private IFloorRepository _floorRepository;

        public OfficeMapController(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public IActionResult Index()
        {
            List<Floor> floors = _floorRepository.GetAll();
            ViewBag.Floors = floors;
            return View();
        }
    }
}
