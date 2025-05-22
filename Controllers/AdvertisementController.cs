using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Repositories;
using ErmakovAppDiplom.Repositories.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ErmakovAppDiplom.Controllers
{
    public class AdvertisementController : Controller
    {
        private IAdvertisementRepository _advertisementRepository;
        private readonly UserManager<User> _userManager;

        public AdvertisementController(IAdvertisementRepository advertisementRepository, UserManager<User> userManager)
        {
            _advertisementRepository = advertisementRepository;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdvertisementCreateViewModel advertisementCreateViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); // или вернуть View с ошибками

            User user = await _userManager.GetUserAsync(User); // текущий пользователь

            var ad = new Advertisement
            {
                Title = advertisementCreateViewModel.Title,
                Description = advertisementCreateViewModel.Description,
                PublishDate = DateTime.UtcNow,
                User = user
            };

            _advertisementRepository.Create(ad);           

            return RedirectToAction("Index", "Home"); // или PartialView, или Ok(), в зависимости от подхода
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            _advertisementRepository.Delete(id);
            return RedirectToAction("Index", "Home");
        }
    }

}
