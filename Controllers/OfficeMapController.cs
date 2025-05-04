using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class OfficeMapController : Controller
    {
        private IFloorRepository _floorRepository;
        private ISubLocationRepository _subLocationRepository;

        public OfficeMapController(IFloorRepository floorRepository, ISubLocationRepository subLocationRepository)
        {
            _floorRepository = floorRepository;
            _subLocationRepository = subLocationRepository;
        }

        public IActionResult Index()
        {
            List<Floor> floors = _floorRepository.GetAll();
            List<SubLocation> locations = _subLocationRepository.GetAll();
            ViewBag.Floors = floors;
            ViewBag.Locations = locations;
            return View();
        }
    }
}
