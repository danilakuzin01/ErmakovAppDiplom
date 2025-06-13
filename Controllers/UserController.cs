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
                    Roles = roles.ToList(),
                    ItemNames = user.Items == null ? new List<string>() : user.Items.Select(i => i.Name).ToList()
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
                        Id = user.Id,
                        FirstName = user.FirstName,
                        SecondName = user.SecondName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        PostName = user.Post?.Name,
                        PostId = user.Post?.Id,
                        LocationName = user.Sublocation?.Location.Name,
                        LocationId = user.Sublocation?.Location.Id,
                        SublocationName = user.Sublocation?.Name,
                        SublocationId = user.Sublocation?.Id,
                        SectionName = user.Section?.Name,
                        SectionId = user.Section?.Id,
                        Email = user.Email,
                        IsActive = user.IsActive,
                        Roles = roles.ToList(),
                        ItemNames = user.Items == null ? new List<string>() : user.Items.Select(i => i.Name).ToList()
                    });
                }
            }

            ViewBag.Search = userFilter.Search;
            ViewBag.SectionSearch = userFilter.SectionId;
            ViewBag.RoleSearch = userFilter.RoleId;

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

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Некорректные данные");

            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound();

            // Обновление основных полей
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.SecondName = model.SecondName;
            user.Email = model.Email;
            user.PhoneNumber = model.Phone;
            user.PostId = model.PostId;
            user.SectionId = model.SectionId;
            user.SublocationId = model.SublocationId;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return BadRequest("Ошибка при обновлении пользователя");

            // Обновление роли, если она изменилась
            var currentRoles = await _userManager.GetRolesAsync(user);
            if (!currentRoles.Contains(model.Role))
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return BadRequest("Ошибка при удалении предыдущих ролей");

                var addResult = await _userManager.AddToRoleAsync(user, model.Role);
                if (!addResult.Succeeded)
                    return BadRequest("Ошибка при добавлении новой роли");
            }

            // Обновление пароля, если он был указан
            //if (!string.IsNullOrWhiteSpace(model.Password))
            //{
            //    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            //    var passwordResult = await _userManager.ResetPasswordAsync(user, token, model.Password);

            //    if (!passwordResult.Succeeded)
            //        return BadRequest("Ошибка при смене пароля");
            //}

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index"); // Перенаправление после удаления
            }

            // Обработка ошибок
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View("Error"); // Или другая обработка ошибок
        }
    }
}
