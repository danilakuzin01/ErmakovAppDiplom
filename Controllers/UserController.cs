using ErmakovAppDiplom.Models;
using ErmakovAppDiplom.Models.ViewModel;
using ErmakovAppDiplom.Repositories.IRepositories;
using ErmakovAppDiplom.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErmakovAppDiplom.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserController(IUserRepository userService, UserManager<User> userManager)
        {
            _userRepository = userService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userRepository.GetAll();
            var userViewModels = new List<UserTableViewModel>();


            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userViewModels.Add(new UserTableViewModel
                {
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    LastName = user.LastName,
                    PostName = user.Post?.Name,
                    LocationName = user.Sublocation?.Location.Name,
                    SublocationName = user.Sublocation?.Name,
                    SectionName = user.Section?.Name,
                    Email = user.Email,
                    IsActive = user.IsActive,
                    Roles = roles.ToList()
                });
            }

            return View(userViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Index(UserFilterViewModel userFilter)
        {
            var users = _userRepository.GetAllByFilter(userFilter);
            var userViewModels = new List<UserTableViewModel>();

            if (users != null)
            {
                foreach (var user in users)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    userViewModels.Add(new UserTableViewModel
                    {
                        FirstName = user.FirstName,
                        SecondName = user.SecondName,
                        LastName = user.LastName,
                        PostName = user.Post?.Name,
                        LocationName = user.Sublocation?.Location.Name,
                        SublocationName = user.Sublocation?.Name,
                        SectionName = user.Section?.Name,
                        Email = user.Email,
                        IsActive = user.IsActive,
                        Roles = roles.ToList()
                    });
                }
            }

            ViewBag.Search = userFilter.Search;

            return View(userViewModels);
        }
    }
}
