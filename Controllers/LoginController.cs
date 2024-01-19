using Microsoft.AspNetCore.Mvc;
using Weather_React_DotNet_Project.Models;
using Weather_React_DotNet_Project.Services;
using System.Threading.Tasks;

namespace Weather_React_DotNet_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserService _userService;

        public LoginController(UserService userService)
        {
            _userService = userService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<User>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userService.AuthenticateUserAsync(userLoginDto.Username, userLoginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            // Here, you can also handle token creation for authenticated users

            return Ok(user);
        }
    }
}
