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
        private IPostRepository _postRepository;
        private ISectionRepository _sectionRepository;
        private ISubLocationRepository _subLocationRepository;

        public UserController(IUserRepository userService, UserManager<User> userManager,
            IPostRepository postRepository, ISectionRepository sectionRepository, ISubLocationRepository subLocationRepository)
        {
            _userRepository = userService;
            _userManager = userManager;
            _postRepository = postRepository;
            _sectionRepository = sectionRepository;
            _subLocationRepository = subLocationRepository;
        }

        public async Task<IActionResult> Index()
        {
            var users = _userRepository.GetAll();
            var userViewModels = new List<UserTableViewModel>();
            ViewBag.Posts = _postRepository.GetAll();
            ViewBag.Sections = _sectionRepository.GetAll();


            ViewBag.SubLocations = _subLocationRepository.GetAll();

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

            ViewBag.Posts = _postRepository.GetAll();
            ViewBag.Sections = _sectionRepository.GetAll();
            ViewBag.SubLocations = _subLocationRepository.GetAll();

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

        public async Task<IActionResult> Create(UserCreateViewModel userCreateViewModel)
        {
            User user = new User
            {
                UserName = userCreateViewModel.Username,
                FirstName = userCreateViewModel.FirstName,
                SecondName = userCreateViewModel.SecondName,
                LastName = userCreateViewModel.LastName,
                Post = _postRepository.GetById(userCreateViewModel.PostId) ?? null,
                Section = _sectionRepository.GetById(userCreateViewModel.SectionId) ?? null,
                Sublocation = _subLocationRepository.GetById(userCreateViewModel.SublocationId) ?? null,
                PhoneNumber = userCreateViewModel.Phone,
                IsActive = true
            };
            var result = await _userManager.CreateAsync(user, userCreateViewModel.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, userCreateViewModel.Role);
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("Index");
        }
    }
}
