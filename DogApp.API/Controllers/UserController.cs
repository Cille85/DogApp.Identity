using Microsoft.AspNetCore.Mvc;
using DogApp.API.Dto.UserDtos;
using DogApp.Services.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;
using DogApp.Shared.EntityUserModels;

namespace DogApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpPost("register")]
        [Consumes("application/json")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = userDto.UserName,
                Email = userDto.UserName // Assuming username is an email, otherwise, adjust as needed
            };

            var result = await _userService.CreateUserAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                return Ok("User registered successfully.");
            }

            var errors = result.Errors.Select(e => new { e.Code, e.Description });
            return BadRequest(errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.LoginAsync(userDto.UserName, userDto.Password, rememberMe: false);

            if (result.Succeeded)
            {
                return Ok("Login successful.");
            }
            else
            {
                return BadRequest("Invalid username or password.");
            }
        }
    }
}
