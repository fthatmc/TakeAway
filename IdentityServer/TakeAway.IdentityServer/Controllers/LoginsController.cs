using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TakeAway.IdentityServer.Dtos;
using TakeAway.IdentityServer.Models;
using TakeAway.IdentityServer.Tools;

namespace TakeAway.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginsController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(LoginUserDto loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, false, false);
            var user = await _userManager.FindByNameAsync(loginUser.Username);
            var userRoles = await _userManager.GetRolesAsync(user);
            var userRole = "";
            if (userRoles.Count > 0)
            {
                userRole = userRoles[0];
            }
            else
            {
                userRole = "Henüz Rol Ataması Yapılamamış.";
            }


            if (result.Succeeded)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = loginUser.Username;
                model.Role = userRole;
                model.Id = user.Id;
                var token = JwtTokenGenerator.GenerateToken(model);

                return Ok(token);
            }
            else
            {
                return Ok("Kullanıcı adı veya şifre hatalı.");
            }
        }
    }
}
