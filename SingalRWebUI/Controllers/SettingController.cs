using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SingalR.EntityLayer.Entities;
using SingalRWebUI.Dtos.IdentityDtos;

namespace SingalRWebUI.Controllers
{
    public class SettingController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDto userEditDto = new UserEditDto
            {
                Name = values.Name,
                Surname = values.Surname,
                Mail = values.Email,
                UserName = values.UserName
            };
            return View(userEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDto userEditDto)
        {
            if (userEditDto.Password == userEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDto.Name;
                user.Surname = userEditDto.Surname;
                user.Email = userEditDto.Mail;
                user.UserName = userEditDto.UserName;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index","Category");
            }
            return View();
        }
    }
}
